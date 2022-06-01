namespace Logic.Queries
{
    public interface IQuery<out T>
    {
        T? GetById(int id);
    }
}
