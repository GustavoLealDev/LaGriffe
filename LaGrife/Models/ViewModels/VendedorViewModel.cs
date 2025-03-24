using LaGrife.Models.Entities;

namespace LaGrife.Models.ViewModels
{
    public class VendedorViewModel
    {
        public Vendedor Vendedor { get; set; }
        public ICollection<Loja> Lojas { get; set; }
    }
}
