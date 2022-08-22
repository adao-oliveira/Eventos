using System.Threading.Tasks;
using InovationStore.Persistence.Contextos;
using InovationStore.Persistence.Contratos;

namespace InovationStore.Persistence
{
    public class GeralPersist : IGeralPersist
    {
        private readonly InovationStoreContext _context;
        public GeralPersist(InovationStoreContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}