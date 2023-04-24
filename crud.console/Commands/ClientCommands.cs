using crud.core.Services;
using crud.dominio.Entidades;

namespace crud.console.Commands
{
    public static class ClientCommands
    {
        public static void GetUserCommand()
        {
            var closeApp = false;
            while (closeApp == false)
            {
                Console.WriteLine("Escolha uma das opções listadas abaixo:");
                Console.WriteLine("\t[ I ] - Inclusão");
                Console.WriteLine("\t[ A ] - Alteração");
                Console.WriteLine("\t[ D ] - Deletar");
                Console.WriteLine("\t[ R ] - Relatórios Gerenciais");
                Console.WriteLine("\t[ S ] - Sair");

                Console.WriteLine("\n");
                Console.WriteLine("Qual a opção desejada? ");

                var opcao = Console.ReadLine();

                while (opcao == string.Empty)
                {
                    Console.WriteLine("Escolha algma opção ou pressione [ S - Sair ] para sair da aplicação.");
                    opcao = Console.ReadLine();
                }

                switch (opcao!.ToUpper())
                {
                    case "0":
                        GetUserCommand();
                        break;
                    case "I":
                        AddCliente();
                        break;
                    case "A":
                        break;
                    case "D":
                        Delete();
                        break;
                    case "R":
                        ReportCommands.GetReportCommand();
                        break;
                    case "S":
                        closeApp = true;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida. Escolha uma das opções.\n");
                        break;
                }
            }
        }

        #region Ações
        public static void AddCliente()
        {
            Console.WriteLine("\n----- CRIAR CONTA -----\n");

            var cliente = new Cliente
            {
                NumeroConta = GetAccountNumberInput(),
                NomeCliente = GetNameInput(),
                SaldoContaCorrente = GetCurrentAccountValueInput(),
                SaldoContaPoupanca = GetSavingAccountValueInput()
            };

            var result = ClienteService.Add(cliente);

            Console.WriteLine($"> {result.Message}\n\n");
        }

        public static void Delete()
        {
            Console.WriteLine("\n----- DELETAR CONTA -----\n");
            Console.WriteLine("\nPor favor, digite o número da conta para realizar a exclusão. Digite 0 para voltar ao menu principal.");

            string commandInput = Console.ReadLine();

            if (string.IsNullOrEmpty(commandInput))
            {
                Console.WriteLine("\nVocê precisa digitar um número de conta.\n");
                Delete();
            }
            else
            {
                var accountNumber = int.Parse(commandInput);

                if (accountNumber == 0) GetUserCommand();

                var result = ClienteService.Delete(accountNumber);

                while (result.Data is null)
                {
                    Console.WriteLine($"\n{result.Message}\n");
                    accountNumber = int.Parse(Console.ReadLine());

                    if (accountNumber == 0) GetUserCommand();

                    if (result.Data is not null) break;
                }

                Console.WriteLine($"> {result.Message}\n\n");
            }
        }
        #endregion

        #region Pegar valores da tela
        public static string GetNameInput()
        {
            Console.WriteLine("Digite o  nome do cliente e pressione Enter");

            var clientName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(clientName)) GetUserCommand();

            if (clientName is string)
            {
                Console.WriteLine("\n");

                return clientName;
            }

            Console.WriteLine("\n\nNome não é válido.\n\n");

            return GetNameInput();
        }

        public static int GetAccountNumberInput(string msg = "Digite o número da conta e pressione Enter. Digite 0 para voltar ao menu principal.")
        {
            Console.WriteLine(msg);

            var accountNumberInput = Console.ReadLine();

            if (accountNumberInput == "0") GetUserCommand();

            var isNumber = int.TryParse(accountNumberInput, out int result);

            if (isNumber)
            {
                Console.WriteLine("\n");

                return result;
            }

            Console.WriteLine("\n\nNão é um número de conta válido. Por favor, digite um número válido.\n\n");

            return GetAccountNumberInput();
        }

        public static double GetCurrentAccountValueInput()
        {
            Console.WriteLine("Digite o saldo da conta corrente e pressione Enter. Digite 0 para voltar ao menu principal.");

            var currentAccountValueInput = Console.ReadLine();

            if (currentAccountValueInput == "0") GetUserCommand();

            var isDouble = double.TryParse(currentAccountValueInput, out double result);

            if (isDouble)
            {
                Console.WriteLine("\n");

                return result;
            }

            Console.WriteLine("\n\nNão é um valor válido. Por favor, digite um válido.\n\n");

            return GetAccountNumberInput();
        }
        public static double GetSavingAccountValueInput()
        {
            Console.WriteLine("Digite o saldo da conta poupança e pressione Enter. Digite 0 para voltar ao menu principal.");

            var savingAccountValueInput = Console.ReadLine();

            if (savingAccountValueInput == "0") GetUserCommand();

            var isDouble = double.TryParse(savingAccountValueInput, out double result);

            if (isDouble)
            {
                Console.WriteLine("\n");

                return result;
            }

            Console.WriteLine("\n\nNão é um valor válido. Por favor, digite um válido.\n\n");

            return GetAccountNumberInput();
        }
        #endregion
    }
}