namespace GameMAQ.Lib
{
    public interface IStartable<T>
    {
        void Initialize(T obj);

        void Start();
    }
}