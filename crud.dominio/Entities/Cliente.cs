namespace crud.dominio.Entidades
{
    public class Cliente
    {
        public int NumeroConta { get; set; }
        public string NomeCliente { get; set; }
        public double SaldoContaCorrente { get; set; }
        public double SaldoContaPoupanca { get; set; }
    }
}