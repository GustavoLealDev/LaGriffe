using LaGrife.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace LaGrife.Models.Entities
{
    public class Venda
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString ="0:dd/MM/yyyy")]
        public DateTime Date { get; set; }
        [DisplayFormat(DataFormatString = "0:F2")]
        public Double Valor { get; set; }
        public VendaStatus Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public Venda()
        {
        }

        public Venda(int id, DateTime date, double valor, VendaStatus status, Vendedor vendedor)
        {
            Id = id;
            Date = date;
            Valor = valor;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
