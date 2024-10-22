
namespace AppAPS.Entities
{
    using System.ComponentModel;
    using System.Reflection;

    public enum Bairro
    {
        [Description("Águas Claras")]
        AguasClaras = 1,

        [Description("Azambuja")]
        Azambuja,

        [Description("Bateas")]
        Bateas,

        [Description("Cedro Alto")]
        CedroAlto,

        [Description("Cedro Baixo")]
        CedroBaixo,

        [Description("Centro")]
        Centro,

        [Description("Dom Joaquim")]
        DomJoaquim,

        [Description("Guarani")]
        Guarani,

        [Description("Limeira Alta")]
        LimeiraAlta,

        [Description("Limeira Baixa")]
        LimeiraBaixa,

        [Description("Limoeiro")]
        Limoeiro,

        [Description("Maluche")]
        Maluche,

        [Description("Nova Brasília")]
        NovaBrasilia,

        [Description("Paquetá")]
        Paquetá,

        [Description("Planalto")]
        Planalto,

        [Description("Poço Fundo")]
        PoçoFundo,

        [Description("Ponta Russa")]
        PontaRussa,

        [Description("Primeiro de Maio")]
        PrimeiroDeMaio,

        [Description("Rio Branco")]
        RioBranco,

        [Description("Santa Luzia")]
        SantaLuzia,

        [Description("Santa Rita")]
        SantaRita,

        [Description("Santa Terezinha")]
        SantaTerezinha,

        [Description("São Luiz")]
        SãoLuiz,

        [Description("São Pedro")]
        SaoPedro,

        [Description("Souza Cruz")]
        SouzaCruz,

        [Description("Steffen")]
        Steffen,

        [Description("Tomaz Coelho")]
        TomazCoelho,

        [Description("Volta Grande")]
        VoltaGrande,

        [Description("Zantão")]
        Zantão
    }

    public enum FormaPagamento
    {
        [Description("Pagamento em Dinheiro")]
        Dinheiro = 1,

        [Description("Cartão de Crédito")]
        CartaoCredito,

        [Description("Cartão de Débito")]
        CartaoDebito,

        [Description("Pagamento via Pix")]
        Pix
    }

    public enum StatusPedido : byte
    {

        [Description("Pedido Confirmado")]
        Confirmado = 0,

        [Description("Pedido em Preparo")]
        EmPreparo,

        [Description("Pronto para Entrega")]
        ProntoParaEntrega,

        [Description("Pedido em Trânsito")]
        EmTransito,

        [Description("Pedido Finalizado")]
        Finalizado
    }

    public enum FormaEntrega : byte
    {
        [Description("Retirar no local")]
        Retirada = 1,

        [Description("Entrega à domicílio")]
        Entrega = 2,
    }

    public enum TipoUsuario : byte
    {
        [Description("Restaurante")]
        Restaurante = 1,

        [Description("Entregador")]
        Entregador = 2,

        [Description("Cliente")]
        Cliente = 3,
    }

    public enum Ingredientes
    {
        [Description("Pão de Hambúrguer")]
        PaoHamburguer,

        [Description("Hambúrguer de Carne Bovina")]
        HamburguerCarneBovina,

        [Description("Hambúrguer de Frango")]
        HamburguerFrango,

        [Description("Hambúrguer Vegetariano")]
        HamburguerVegetariano,

        [Description("Queijo Cheddar")]
        QueijoCheddar,

        [Description("Queijo Mussarela")]
        QueijoMussarela,

        [Description("Bacon Crocante")]
        BaconCrocante,

        [Description("Alface Americana")]
        AlfaceAmericana,

        [Description("Tomate Fatiado")]
        TomateFatiado,

        [Description("Cebola Roxa")]
        CebolaRoxa,

        [Description("Molho Barbecue")]
        MolhoBarbecue,

        [Description("Molho de Maionese")]
        MolhoMaionese,

        [Description("Molho de Mostarda e Mel")]
        MolhoMostardaMel,

        [Description("Picles")]
        Picles,

        [Description("Pepperoni")]
        Pepperoni,

        [Description("Ovo Frito")]
        OvoFrito,

        [Description("Batata Palha")]
        BatataPalha,

        [Description("Milho Verde")]
        MilhoVerde,

        [Description("Cenoura Ralada")]
        CenouraRalada,

        [Description("Ketchup")]
        Ketchup,

        [Description("Molho de Pimenta")]
        MolhoPimenta,

        [Description("Queijo Gorgonzola")]
        QueijoGorgonzola,

        [Description("Azeitonas Pretas")]
        AzeitonasPretas,

        [Description("Molho Ranch")]
        MolhoRanch,

        // Ingredientes de bebidas
        [Description("Gelo")]
        Gelo,

        [Description("Açúcar")]
        Acucar,

        [Description("Suco de Limão")]
        SucoLimao,

        [Description("Suco de Laranja")]
        SucoLaranja,

        [Description("Polpa de Morango")]
        PolpaMorango,

        [Description("Polpa de Maracujá")]
        PolpaMaracuja,

        [Description("Leite")]
        Leite,

        [Description("Sorvete de Baunilha")]
        SorveteBaunilha,

        [Description("Sorvete de Chocolate")]
        SorveteChocolate,

        [Description("Creme de Leite")]
        CremeLeite,

        [Description("Leite Condensado")]
        LeiteCondensado,

        [Description("Hortelã")]
        Hortela,

        [Description("Rum Branco")]
        RumBranco,

        [Description("Tequila")]
        Tequila,

        [Description("Vodka")]
        Vodka,

        [Description("Cachaça")]
        Cachaca,

        [Description("Licor de Laranja")]
        LicorLaranja,

        [Description("Xarope de Groselha")]
        XaropeGroselha,

        [Description("Xarope de Açúcar")]
        XaropeAcucar
    }

    public enum Medida : byte
    {
        [Description("UN")]
        UN = 1,
        [Description("GR")]
        GR = 2,
        [Description("ML")]
        ML = 3,
    }

    public enum PeriodoFiltro : byte
    {
        [Description("Hoje")]
        Hoje = 1,

        [Description("Semana atual")]
        SemanaAtual,

        [Description("Mês atual")]
        MesAtual,

        [Description("Mês anterior")]
        MesAnterior,

        [Description("Ano atual")]
        AnoAtual,
    }

    public class EnumItem<T>
    {
        public string Description { get; set; }
        public T Value { get; set; }

        public EnumItem(string description, T value)
        {
            Description = description;
            Value = value;
        }

        public override string ToString() => Description;
    }

    public static class EnumHelper
    {
        public static List<EnumItem<T>> GetEnumItems<T>() where T : Enum
        {
            return typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static)
                            .Select(f => new EnumItem<T>(
                                f.GetCustomAttribute<DescriptionAttribute>()?.Description ?? f.Name,
                                (T)f.GetValue(null)))
                            .ToList();
        }

        public static string GetEnumDescription<T>(T value) where T : Enum
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var descriptionAttribute = fieldInfo?.GetCustomAttribute<DescriptionAttribute>();
            return descriptionAttribute?.Description ?? value.ToString();
        }
    }

}
