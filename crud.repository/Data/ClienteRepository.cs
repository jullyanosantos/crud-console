using crud.dominio.Entidades;
using System.Reflection.Emit;
using System.Text.Json;

namespace crud.infra.Data
{
    public static class ClienteRepository
    {
        private static string fileName = "tb_clientes.txt";
        private static string applicationPath = Path.GetFullPath(System.AppDomain.CurrentDomain.BaseDirectory);
        private static string saveFilePath = Path.Combine(applicationPath, fileName);

        public static Cliente Add(Cliente cliente)
        {
            var newCliente = JsonSerializer.Serialize(cliente);

            using (StreamWriter writer = new(saveFilePath, true))
            {
                writer.WriteLine(newCliente);
            }

            return cliente;
        }

        public static bool Delete(int accountNumber)
        {
            List<string> linhas = new();
            var index = 0;
            var indexRemove = 0;

            using (StreamReader sr = new(saveFilePath))
            {
                while (!sr.EndOfStream)
                {
                    var linha = sr.ReadLine();

                    linhas.Add(linha);

                    var cliente = JsonSerializer.Deserialize<Cliente>(linha);

                    if (cliente.NumeroConta == accountNumber)
                    {
                        indexRemove = index;
                    }

                    index++;
                }
            }

            linhas.RemoveAt(indexRemove); //Remove a linha

            //Reescrever o arquivo linha a linha:
            using (StreamWriter sw = new(saveFilePath, false))
            {
                bool first = true;
                foreach (string str in linhas)
                {
                    if (first)
                        first = false;
                    else
                        sw.WriteLine();
                    sw.Write(str);
                }
            }

            return true;
        }

        public static Cliente Get(int accountNumber)
        {

            return null;
        }

        public static List<Cliente> GetAll()
        {
            var lst = new List<Cliente>();

            if (File.Exists(saveFilePath))
            {
                var values = File.ReadAllLines(saveFilePath);

                if (values.Any())
                {
                    foreach (var item in values)
                    {
                        var cliente = JsonSerializer.Deserialize<Cliente>(item);

                        if (cliente is not null)
                            lst.Add(cliente);
                    }
                }
            }

            return lst;
        }
    }
}