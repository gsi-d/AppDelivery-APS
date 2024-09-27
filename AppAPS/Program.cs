using AppAPS.Components;
using AppAPS.Components.Account;
using AppAPS.Data;
using AppAPS.Entities;
using AppAPS.Interfaces;
using AppAPS.Services;
using AppAPS.Services.Model;
using AppAPS.Validators;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.FluentUI.AspNetCore.Components;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddFluentUIComponents();

builder.Services.AddScoped<SessaoUsuario>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IUploadService, UploadService>();

var assembly = Assembly.Load("AppAPS");
var classesMapeamento = assembly.GetTypes().Where(tipo => typeof(Profile).IsAssignableFrom(tipo) && !tipo.IsAbstract && tipo.IsPublic);
var mappingConfig = new MapperConfiguration(mc =>
{
    // Adicione seus perfis de mapeamento aqui
    foreach (var mapeamento in classesMapeamento)
    {
        mc.AddProfile(mapeamento);
    }
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
builder.Services.AddTransient<IValidator<Pedido>, PedidoValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
