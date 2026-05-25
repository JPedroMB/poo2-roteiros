[Serializable]
public class SaldoInsuficienteException : Exception
{
    public decimal QuantiaSaque { get; }
    public decimal SaldoDisponivel { get; }

    public SaldoInsuficienteException() { }

    public SaldoInsuficienteException(string descricao) : base(descricao) { }

    public SaldoInsuficienteException(string descricao, Exception causaInterna) : base(descricao, causaInterna) { }

    public SaldoInsuficienteException(decimal quantiaSolicitada, decimal saldoEmConta, Exception causaInterna) 
        : base($"Operação de saque no valor de {quantiaSolicitada} foi recusada. O saldo disponível na conta é R$ {saldoEmConta}.", causaInterna)
    {
        QuantiaSaque = quantiaSolicitada;
        SaldoDisponivel = saldoEmConta;
    }

    public override string HelpLink => "https://centralatendimento.banco.com.br/suporte/erro-saldo-insuficiente";
}