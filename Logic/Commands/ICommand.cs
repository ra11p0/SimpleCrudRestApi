namespace Logic.Commands
{
    public interface ICommand<in T>
    {
        void Create(T obj);
        void Update(T obj);
        void Delete(int id);
    }
}
