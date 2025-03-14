namespace LaGrife.Models.Entities
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime Aniversario { get; set; }
        public Loja Loja { get; set; }
        public ICollection<Vendas> Vendas { get; set; } = new List<Vendas>();

        public Vendedor()
        {
        }

        public Vendedor(int id, string nome, string email, DateTime aniversario, Loja loja)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Aniversario = aniversario;
            Loja = loja;
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
