using LaGrife.Models.Entities;

namespace LaGrife.Services
{
    public class LojasService
    {
        private readonly LaGrifeContext _context;

        public LojasService(LaGrifeContext context)
        {
            _context = context;
        }

        public List<Loja> FindAll()
        {
            return _context.Loja.OrderBy(x => x.Local).ToList();
        }
    }
}
