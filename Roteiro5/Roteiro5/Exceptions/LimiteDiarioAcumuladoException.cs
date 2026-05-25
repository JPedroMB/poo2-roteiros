[Serializable]
public class LimiteDiarioAcumuladoException : Exception
{
    public decimal TotalRetiradoNoDia { get; }
    public decimal LimiteMaximoDiario { get; }

    public LimiteDiarioAcumuladoException(decimal totalRetirado, decimal limiteDiario) 
        : base($"O limite acumulado para saques diários foi atingido. Valor já retirado hoje: R$ {totalRetirado}. O limite diário total permitido é R$ {limiteDiario}.", null)
    {
        TotalRetiradoNoDia = totalRetirado;
        LimiteMaximoDiario = limiteDiario;
    }

    public override string HelpLink => "https://centralatendimento.banco.com.br/suporte/erro-limite-diario-acumulado";
}