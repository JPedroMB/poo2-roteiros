[Serializable]
public class LimiteDiarioException : Exception // Exercício 2 - Implementação de Exceção Personalizada
{
    public LimiteDiarioException() { }
    
    public LimiteDiarioException(string msg) : base(msg) { }
    
    public LimiteDiarioException(string msg, Exception originalEx) : base(msg, originalEx) { }
    
    public LimiteDiarioException(decimal valorSaque, decimal limiteMaximoTransacao, Exception originalEx) 
        : base($"O valor de saque solicitado (R$ {valorSaque}) ultrapassa o limite individual permitido por transação de R$ {limiteMaximoTransacao}.", originalEx) { }
    
    public override string HelpLink => "https://centralatendimento.banco.com.br/suporte/erro-limite-saque";
}