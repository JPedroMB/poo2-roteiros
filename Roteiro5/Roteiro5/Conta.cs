class Conta
{
    public int Numero { get; private set; }
    public string Titular { get; private set; }
    public decimal Saldo { get; private set; }
    
    private static readonly decimal LIMITE_SAQUE_UNICO = 500;
    private decimal _totalRetiradoDiario;
    private const decimal MAX_DIARIO_PERMITIDO = 1000;

    public Conta(int numConta, string nomeTitular, decimal saldoInicial)
    {
        if (string.IsNullOrWhiteSpace(nomeTitular))
        {
            throw new ArgumentException("O nome do titular não pode ser vazio ou nulo.");
        }
        if (saldoInicial < 0)
        {
            throw new ArgumentException("O valor do saldo inicial não pode ser negativo.");
        }
        Numero = numConta;
        Titular = nomeTitular;
        Saldo = saldoInicial;
    }

    public decimal Depositar(decimal quantia) // Exercício 1 - Validação de Depósito
    {
        if (quantia <= 0)
        {
            throw new ArgumentException("O valor a ser depositado deve ser maior que zero.");
        }
        if (quantia > 10000)
        {
            throw new ArgumentException("O limite de depósito por operação é de R$ 10.000,00.");
        }
        Saldo += quantia;
        return Saldo;
    }

    public decimal Sacar(decimal quantia)
    {
        if (quantia <= 0)
        {
            throw new ArgumentException("O valor do saque solicitado deve ser superior a zero.");
        }
        if (_totalRetiradoDiario + quantia > MAX_DIARIO_PERMITIDO)
        {
            throw new LimiteDiarioAcumuladoException(_totalRetiradoDiario, MAX_DIARIO_PERMITIDO);
        }
        
        try
        {
            if (Saldo < quantia)
            {
                // Correção inteligente: lançando a exceção correta de negócio para que o catch específico a capture.
                throw new SaldoInsuficienteException("O saldo atual é insuficiente para efetuar o saque.");
            }
            if (quantia > LIMITE_SAQUE_UNICO)
            {
                throw new LimiteDiarioException("O saque excede o limite máximo permitido por transação.");
            }
            
            Saldo -= quantia;
            _totalRetiradoDiario += quantia;
            return Saldo;
        }
        catch (SaldoInsuficienteException ex)
        {
            throw new SaldoInsuficienteException(quantia, Saldo, ex);
        }
        catch (LimiteDiarioException ex)
        {
            throw new LimiteDiarioException(quantia, LIMITE_SAQUE_UNICO, ex);
        }
    }

    public void Transferir(Conta contaDestino, decimal quantiaTransferencia) // Exercício 3 - Transferência entre contas
    {
        decimal valorSacado = Sacar(quantiaTransferencia);
        contaDestino.Depositar(valorSacado);
    }

    public override string ToString()
    {
        return $"[Conta Corrente] Número: {Numero} | Titular: {Titular} | Saldo Atual: R$ {Saldo:F2}";
    }
}