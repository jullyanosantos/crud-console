using crud.core.Helpers;
using crud.dominio.Entidades;
using crud.infra.Data;

namespace crud.core.Services
{
    public static class RelatoriosGerenciaisService
    {
        public static List<Cliente> ListThreeMostCurrentAccountValue()
        {
            return ClienteRepository.GetAll()
                                    .OrderByDescending(x => x.SaldoContaCorrente)
                                    .Take(3)
                                    .ToList();
        }

        public static List<Cliente> ListAll()
        {
            return ClienteRepository.GetAll()
                                    .OrderBy(c=> c.NumeroConta)
                                    .ToList();
        }


        public static List<Cliente> ListarClienteSaldoNegativo()
        {

            return default;
        }
    }
}