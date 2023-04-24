using crud.core.Helpers;
using crud.dominio.Entidades;
using crud.infra.Data;

namespace crud.core.Services
{
    public static class ClienteService
    {
        public static BaseResult<Cliente> Add(Cliente cliente)
        {
            var response = new BaseResult<Cliente>();

            if (ClienteRepository.GetAll().Any(c => c.NumeroConta == cliente.NumeroConta))
            {
                response.Success = false;
                response.Message = $"Cliente já existe cadastrado com a conta {cliente.NumeroConta}";
                response.Data = cliente;
            }
            else
            {
                var inserted = ClienteRepository.Add(cliente);

                response.Success = true;
                response.Message = $"Cliente cadastrado com sucesso.";
                response.Data = inserted;
            }

            return response;
        }

        public static Cliente Update(Cliente cliente)
        {

            return cliente;
        }

        public static BaseResult<Cliente> Delete(int accountNumber)
        {
            var result = new BaseResult<Cliente>();
            var clienteExists = ClienteRepository.GetAll().FirstOrDefault(c => c.NumeroConta == accountNumber);

            if (clienteExists != null)
            {
                var deleted = ClienteRepository.Delete(accountNumber);

                result.Success = deleted;
                result.Message = $"Cliente {clienteExists.NumeroConta} excluído com sucesso.";
                result.Data = clienteExists;
            }
            else
            {
                result.Success = false;
                result.Message = result.Message = $"Cliente com númuero de conta {accountNumber} não existe. Tente novamente ou digite 0 para voltar ao menu principal.";
                result.Data = clienteExists;
            }

            return result;
        }


        private static Cliente Get(int accountNumber)
        {
            return null;
        }
    }
}