
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

        [Description("Rio Pardo")]
        RioPardo,

        [Description("Santa Luzia")]
        SantaLuzia,

        [Description("Santa Rita")]
        SantaRita,

        [Description("São João")]
        SãoJoão,

        [Description("São Luiz")]
        SãoLuiz,

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
