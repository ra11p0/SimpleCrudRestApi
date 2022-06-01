using DatabaseAccess;

namespace Logic.Commands
{
    public abstract class CommandTemplate<T> : ICommand<T>
    {
        protected readonly CarCrudDbContext Context;

        protected CommandTemplate(CarCrudDbContext context)
        {
            this.Context = context;
        }

        public abstract void Create(T obj);

        public abstract void Update(T obj);

        public abstract void Delete(int id);
    }
}
