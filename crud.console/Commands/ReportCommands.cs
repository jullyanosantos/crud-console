using crud.core.Services;

namespace crud.console.Commands
{
    public static class ReportCommands
    {
        public static void GetReportCommand()
        {
            var closeApp = false;
            while (closeApp == false)
            {
                Console.WriteLine("\n\nEscolha uma das opções listadas abaixo:");
                Console.WriteLine("\t[ 0 ] - Sair");
                Console.WriteLine("\t[ 1 ] - Lisar Clientes Saldo Negativo");
                Console.WriteLine("\t[ 2 ] - Listar Clientes com saldo acima de um valor");
                Console.WriteLine("\t[ 3 ] - Listar todas as contas");
                Console.WriteLine("\t[ 4 ] - Listar os 3 maiores saldos de conta corrente");
                Console.WriteLine("\t[ 10 ] - Voltar para o menu anterios");

                Console.WriteLine("\n");
                Console.WriteLine("Qual a opção desejada? ");

                string commandInput = Console.ReadLine();

                if (string.IsNullOrEmpty(commandInput))
                {
                    Console.WriteLine("\nEscolha algma opção ou pressione [ 0 - Sair ] para sair da aplicação.\n");
                    GetReportCommand();
                }

                int command = Convert.ToInt32(commandInput);

                switch (command)
                {
                    case 0:
                        closeApp = true;
                        Environment.Exit(0);
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        ListAll();
                        break;
                    case 4:
                        ListThreeMostCurrentAccountValue();
                        break;
                    case 10:
                        ClientCommands.GetUserCommand();
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida. Escolha uma das opções.\n");
                        break;
                }
            }
        }

        #region Ações

        public static void ListAll()
        {
            var lst = RelatoriosGerenciaisService.ListAll();

            Console.WriteLine("\nSegue abaixo todas as contas.\n");

            foreach (var item in lst)
            {
                Console.WriteLine($"> Numero Conta: {item.NumeroConta} | Cliente: {item.NomeCliente} | Saldo: {item.SaldoContaCorrente}");
            }
        }
        public static void ListThreeMostCurrentAccountValue()
        {
            var lst = RelatoriosGerenciaisService.ListThreeMostCurrentAccountValue();

            Console.WriteLine("\nSegue abaixo os 3 maiores Saldos da Conta corrente.\n");

            foreach (var item in lst)
            {
                Console.WriteLine($"> Cliente: {item.NomeCliente} | Saldo: {item.SaldoContaCorrente} \n\n");
            }
        }
        #endregion
    }
}
