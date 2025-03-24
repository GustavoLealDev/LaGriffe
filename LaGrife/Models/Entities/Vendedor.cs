using System.ComponentModel.DataAnnotations;

namespace LaGrife.Models.Entities
{
    public class Vendedor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatorio!!")]
        [StringLength(60, MinimumLength =4, ErrorMessage = "Erro ao inserir nome! Tente novamente")]
        public string Nome { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Entre com email válido")]
        [Required(ErrorMessage = "O Email é obrigatorio!!")]
        public string Email { get; set; }
        [Display(Name = "Data de Aniversário")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "A data de aniversário é obrigatorio!!")]
        public DateTime Aniversario { get; set; }
        public Loja Loja { get; set; }
        public int LojaId { get; set; }
        public ICollection<Vendas> Vendas { get; set; } = new List<Vendas>();

        public Vendedor()
        {
        }

        public Vendedor(int id, string nome, string email, DateTime aniversario)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Aniversario = aniversario;
        }
        public void AddVendas(Vendas vendas)
        {
            Vendas.Add(vendas);
        }

        public void RemoveVendas(Vendas vendas)
        {
            Vendas.Remove(vendas);
        }

        public double VendasTotais(DateTime inicio, DateTime final)
        {
            return Vendas.Where(vendas => vendas.Date >= inicio && vendas.Date <= final).Sum(vendas => vendas.Valor);
        }
    }
}