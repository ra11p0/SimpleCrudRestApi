using DatabaseAccess;

namespace Logic.Queries
{
    public abstract class QueryTemplate<T> : IQuery<T>
    {
        protected readonly CarCrudDbContext Context;

        protected QueryTemplate(CarCrudDbContext context)
        {
            this.Context = context;
        }

        public abstract T? GetById(int id);
    }
}
