namespace LaGrife.Models.Entities
{
    public class Loja
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();

        public Loja() 
        {
        }

        public Loja(int id, string local)
        {
            Id = id;
            Local = local;
        }

        public void AddVendedor(Vendedor vendedor)
        {
            Vendedores.Add(vendedor);
        }

        public double VendasTotais(DateTime inicio, DateTime final)
        {
            return Vendedores.Sum(vendedores => vendedores.VendasTotais(inicio, final));
        }

    }
}
