using LaGrife.Models.Enums;

namespace LaGrife.Models.Entities
{
    public class Vendas
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Double Valor { get; set; }
        public VendaStatus Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public Vendas()
        {
        }

        public Vendas(int id, DateTime date, double valor, VendaStatus status, Vendedor vendedor)
        {
            Id = id;
            Date = date;
            Valor = valor;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
