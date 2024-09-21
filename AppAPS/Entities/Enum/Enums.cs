using System.ComponentModel;

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



    public enum StatusPedido : byte
    {
        EmAberto,
        Confirmado,
        ProntoParaEntrega,
        EmTransito,
        Finalizado
    }
}
