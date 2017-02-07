namespace TimeTracker.Model.Common
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}