using LaGrife.Models.Entities;

namespace LaGrife.Models.ViewModels
{
    public class VendedorFormViewModel
    {
        public Vendedor vendedor { get; set; }
        public ICollection<Loja> Lojas { get; set; }
    }
}
