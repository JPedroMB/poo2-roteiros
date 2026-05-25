using System;
using NLog;

namespace MonitoramentoFinanceiroNLog
{
    class Program
    {
        // Criação da instância do logger personalizado para a classe principal
        private static readonly Logger DiarioLog = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            // Exercício 2: Registro do início da execução da aplicação
            DiarioLog.Info("Iniciando a execução do programa principal.");

            try
            {
                // Exercício 3: Teste de conversão de string inválida para inteiro com captura e log do erro
                string textoParaConversao = "123a";
                DiarioLog.Info($"Tentando realizar o parse da string: '{textoParaConversao}'");

                try
                {
                    int numeroResultado = int.Parse(textoParaConversao);
                }
                catch (FormatException ex)
                {
                    // Exercício 5 e 7: Log do tipo ERROR registrando a exceção formatada
                    DiarioLog.Error(ex, "Erro de processamento: Falha na conversão de string para o tipo int.");
                }

                // Exercício 4 e 6: Instanciação e operação de contas com log automático
                ContaBancaria contaRemetente = new ContaBancaria("Conta-Alfa", 500.00m);
                ContaBancaria contaDestinataria = new ContaBancaria("Conta-Beta", 100.00m);

                // Fluxo 1: Depósito de valores
                contaRemetente.Depositar(200.00m);

                // Fluxo 2: Saque efetuado com sucesso
                contaRemetente.Sacar(150.00m);

                // Fluxo 3: Transferência entre contas
                contaRemetente.Transferir(100.00m, contaDestinataria);

                // Fluxo 4: Operação inválida (saque acima do limite do saldo da conta)
                try
                {
                    contaRemetente.Sacar(3000.00m);
                }
                catch (Exception)
                {
                    // O aviso de saldo insuficiente é registrado de forma interna pela própria conta
                }
                
                // Outro teste de conversão para forçar uma exceção global não tratada
                int.Parse("ConversaoInvalidaTotal");
            }
            catch (Exception ex)
            {
                // Captura e registra qualquer outra exceção genérica no nível do método Main
                DiarioLog.Error(ex, "Falha crítica não tratada interceptada no escopo principal.");
            }
            finally
            {
                // Exercício 2: Registro do término da execução
                DiarioLog.Info("Finalizando a execução do programa.");
            }
        }
    }

    // Classe ContaBancaria contendo logging integrado para os Exercícios 4 e 6
    public class ContaBancaria
    {
        private static readonly Logger DiarioLog = LogManager.GetCurrentClassLogger();
        public string IdentificadorConta { get; set; }
        public decimal Saldo { get; private set; }

        public ContaBancaria(string codConta, decimal saldoInicial)
        {
            IdentificadorConta = codConta;
            Saldo = saldoInicial;
            DiarioLog.Info($"Conta [{IdentificadorConta}] inicializada no sistema. Saldo inicial: R$ {Saldo:F2}");
        }

        public void Depositar(decimal quantia)
        {
            DiarioLog.Info($"[OPERACAO: DEPÓSITO] Iniciando transação na conta {IdentificadorConta}. Valor solicitado: R$ {quantia:F2}");
            
            if (quantia <= 0)
            {
                // Exercício 5: Registro de nível WARN para tentativas de operação inválidas
                DiarioLog.Warn($"[OPERACAO: DEPÓSITO] Tentativa negada. O valor deve ser estritamente superior a zero: R$ {quantia:F2}");
                throw new ArgumentException("O valor do depósito precisa ser maior que zero.");
            }

            Saldo += quantia;
            DiarioLog.Info($"[OPERACAO: DEPÓSITO] Sucesso! Depósito realizado. Saldo atualizado: R$ {Saldo:F2}");
        }

        public void Sacar(decimal quantia)
        {
            DiarioLog.Info($"[OPERACAO: SAQUE] Iniciando transação na conta {IdentificadorConta}. Valor solicitado: R$ {quantia:F2}");

            if (quantia <= 0)
            {
                DiarioLog.Warn($"[OPERACAO: SAQUE] Tentativa negada. O valor para saque deve ser estritamente superior a zero: R$ {quantia:F2}");
                throw new ArgumentException("O valor do saque precisa ser maior que zero.");
            }

            if (Saldo < quantia)
            {
                // Exercício 5: Registro de nível WARN para saldo insuficiente (operação de negócio negada)
                DiarioLog.Warn($"[OPERACAO: SAQUE] Tentativa recusada (Saldo Insuficiente). Saldo disponível: R$ {Saldo:F2} | Valor solicitado: R$ {quantia:F2}");
                throw new InvalidOperationException("Não há saldo suficiente em conta para realizar esta operação.");
            }

            Saldo -= quantia;
            DiarioLog.Info($"[OPERACAO: SAQUE] Sucesso! Saque realizado. Saldo atualizado: R$ {Saldo:F2}");
        }

        public void Transferir(decimal quantia, ContaBancaria contaDestino)
        {
            DiarioLog.Info($"[OPERACAO: TRANSFERÊNCIA] Iniciando envio de R$ {quantia:F2} da conta {IdentificadorConta} para a conta {contaDestino.IdentificadorConta}");

            try
            {
                // Reaproveita os métodos internos de saque e depósito com validação e logs automáticos
                this.Sacar(quantia);
                contaDestino.Depositar(quantia);

                DiarioLog.Info($"[OPERACAO: TRANSFERÊNCIA] Sucesso! Transferência efetuada com êxito entre as contas.");
            }
            catch (Exception ex)
            {
                // Exercício 5: Registro de nível ERROR para exceções em transferências
                DiarioLog.Error(ex, $"[OPERACAO: TRANSFERÊNCIA] Falha crítica. Não foi possível realizar a transferência de R$ {quantia:F2} de {IdentificadorConta} para {contaDestino.IdentificadorConta}");
                throw;
            }
        }
    }
}