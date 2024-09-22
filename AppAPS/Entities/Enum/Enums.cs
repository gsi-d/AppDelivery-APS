
namespace AppAPS.Entities.Enum
{
    using System.ComponentModel;

    public enum Bairro
    {
        [Description("Águas Claras")]
        ÁguasClaras,

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

        [Description("Ponta Russas")]
        PontaRussas,

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
        CartaoCredito = 2,

        [Description("Cartão de Débito")]
        CartaoDebito = 3,

        [Description("Pagamento via Pix")]
        Pix = 4
    }

    public enum StatusPedido : byte
    {
        [Description("Pedido em Aberto")]
        EmAberto = 0,

        [Description("Pedido Confirmado")]
        Confirmado = 1,

        [Description("Pronto para Entrega")]
        ProntoParaEntrega = 2,

        [Description("Pedido em Trânsito")]
        EmTransito = 3,

        [Description("Pedido Finalizado")]
        Finalizado = 4
    }

}
