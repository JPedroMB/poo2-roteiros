class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("=== Abertura e Movimentação de Conta Corrente ===");
            
            Console.Write("Nome do titular da conta: ");
            string titularInformado = Console.ReadLine() ?? string.Empty;
            
            Console.Write("Número de identificação da conta: ");
            if (!int.TryParse(Console.ReadLine(), out int numContaInformado))
            {
                throw new ArgumentException("Número de conta inválido.");
            }
            
            Console.Write("Saldo inicial a ser depositado (R$): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal saldoInicialInformado))
            {
                throw new ArgumentException("Saldo inicial digitado é inválido.");
            }

            Conta contaAtiva = new Conta(numContaInformado, titularInformado, saldoInicialInformado);
            Console.WriteLine("\nConta criada com sucesso!");
            Console.WriteLine(contaAtiva);
            
            Console.WriteLine($"\n[Consulta] Saldo Atual: R$ {contaAtiva.Saldo:F2}");
            
            // Simulações de transações de Saques sequenciais
            Console.WriteLine("\nExecutando saques de teste...");
            
            Console.WriteLine("-> Solicitando saque de R$ 500,00...");
            contaAtiva.Sacar(500);
            
            Console.WriteLine("-> Solicitando saque de R$ 500,00...");
            contaAtiva.Sacar(500);
            
            Console.WriteLine("-> Solicitando saque de R$ 500,00...");
            contaAtiva.Sacar(500);
            
            Console.WriteLine($"[Consulta] Saldo Final: R$ {contaAtiva.Saldo:F2}");
        }
        catch (SaldoInsuficienteException erroNegocio)
        {
            Console.WriteLine("\n[FALHA DE OPERAÇÃO] Regra de negócio violada:");
            Console.WriteLine($"Mensagem: {erroNegocio.Message}");
            Console.WriteLine($"Link para Ajuda: {erroNegocio.HelpLink}");
            Console.WriteLine($"Rastreamento de Pilha:\n{erroNegocio.StackTrace}");
            if (erroNegocio.InnerException != null)
            {
                Console.WriteLine($"Causa Interna original: {erroNegocio.InnerException.Message}");
            }
        }
        catch (LimiteDiarioException erroLimite) // Exercício 4 - Tratamento e exibição de detalhes das exceções
        {
            Console.WriteLine("\n[FALHA DE OPERAÇÃO] Limite individual de transação excedido:");
            Console.WriteLine($"Mensagem: {erroLimite.Message}");
            Console.WriteLine($"Link de Suporte: {erroLimite.HelpLink}");
            Console.WriteLine($"Rastreamento de Pilha:\n{erroLimite.StackTrace}");
            if (erroLimite.InnerException != null)
            {
                Console.WriteLine($"Causa Interna original: {erroLimite.InnerException.Message}");
            }
        }
        catch (LimiteDiarioAcumuladoException erroAcumulado)
        {
            Console.WriteLine($"\n[FALHA DE OPERAÇÃO] Limite diário acumulado ultrapassado:");
            Console.WriteLine($"Mensagem: {erroAcumulado.Message}");
            Console.WriteLine($"Link de Suporte: {erroAcumulado.HelpLink}");
        }
        catch (ArgumentException erroValidacao)
        {
            Console.WriteLine($"\n[ERRO DE VALIDAÇÃO] Parâmetros incorretos: {erroValidacao.Message}");
        }
        catch (Exception erroGeral)
        {
            Console.WriteLine("\n[ERRO INESPERADO] Ocorreu um problema grave no sistema:");
            Console.WriteLine($"Mensagem: {erroGeral.Message}");
            Console.WriteLine($"StackTrace: {erroGeral.StackTrace}");
            
            /*
             * Exercício 5 - Tratamento Correto de Propagação de Exceções
             * 
             * Diferença crucial entre 'throw;' e 'throw ex;':
             * 1. throw ex; -> Reinicializa o rastreamento da pilha de chamadas (Stack Trace). O runtime entende que a exceção 
             *    se originou no próprio bloco catch onde o throw foi executado, ocultando o histórico real de chamadas internas 
             *    onde o erro de fato aconteceu.
             * 2. throw; -> Encaminha a exceção adiante mantendo o Stack Trace original intacto. Isso preserva a origem exata da 
             *    falha, facilitando a depuração e análise da causa raiz do erro em métodos profundos.
             */

            /*
             * Exercício 7 - Perguntas Conceituais sobre Exceções no C#
             * 
             * 1. Por que usar exceção personalizada aqui?
             *    - Expressividade e Semântica: O tratamento de erros fica muito mais legível e alinhado às regras de negócio. 
             *      Um bloco "catch (SaldoInsuficienteException)" diz com clareza qual regra bancária foi infringida.
             *    - Captura Direcionada: Permite tratar cenários de negócio de forma isolada e específica (como avisar o usuário 
             *      para recarregar o saldo) enquanto erros de infraestrutura ou falhas técnicas gerais seguem outro fluxo de tratamento.
             *    - Estruturação de Metadados: É possível embutir propriedades personalizadas na classe da exceção (como quantia do saque 
             *      tentado ou saldo restante), facilitando a geração de logs ricos e mensagens de suporte customizadas.
             * 
             * 2. Qual a função do InnerException?
             *    - Preservação do Histórico (Causa Raiz): Quando interceptamos uma exceção técnica de baixo nível e a envelopamos 
             *      em uma exceção de negócio de alto nível, o InnerException guarda a referência do erro original.
             *    - Rastreabilidade Completa: Garante que o desenvolvedor possa inspecionar os detalhes reais do erro original 
             *      (ex: erro de banco de dados por meio de ex.InnerException) mesmo que o usuário final visualize um erro simplificado.
             * 
             * 3. Onde o erro deve ser tratado: Conta ou Main?
             *    - A regra essencial do desenvolvimento é tratar a exceção no ponto da aplicação que possui contexto para decidir o 
             *      que fazer a seguir (normalmente na camada de Interface de Usuário ou nos Controladores).
             *    - Classe Conta: Deve apenas validar suas regras de negócio e disparar as exceções ("throw") se as regras forem violadas. 
             *      Ela não deve usar "Console.WriteLine" ou tentar se recuperar do erro diretamente, para não misturar lógica de domínio 
             *      com detalhes de exibição.
             *    - Classe Program (Main): Representando o ponto de interação direta com o usuário final, é o local ideal para capturar 
             *      os erros ("catch"), exibir mensagens amigáveis na tela e solicitar novas tentativas ou encerrar a execução adequadamente.
             */
        }
    }
}