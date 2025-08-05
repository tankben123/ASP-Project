namespace WebApp.Models
{
    public class TransitionRepository
    {
        private readonly StoreContext _context;
        public TransitionRepository(StoreContext context)
        {
            _context = context;
        }
        public List<Transition>? GetTransitions(int stateId)
        {
            return _context.Transitions
                .Where(t => t.FromStateId.HasValue && t.FromStateId == stateId)
                .ToList();
        }
    }
}
