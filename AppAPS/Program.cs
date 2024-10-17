using AppAPS.Components;
using AppAPS.Data;
using AppAPS.Entities;
using AppAPS.Interfaces;
using AppAPS.Services;
using AppAPS.Services.Model;
using AppAPS.Validators;
using AutoMapper;
using Blazored.LocalStorage;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.FluentUI.AspNetCore.Components;
using Radzen;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddFluentUIComponents();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddRadzenComponents();

builder.Services.AddScoped<SessaoUsuario>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
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

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddTransient<IValidator<Pedido>, PedidoValidator>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate(); // Aplica as migrations pendentes
    }
    catch (Exception ex)
    {
        // Log ou trate o erro conforme necessário
        Console.WriteLine($"Erro ao aplicar as migrations: {ex.Message}");
    }
}

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

app.Run();
