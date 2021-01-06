namespace GameMAQ.Lib
{
    public interface IRenderable<T> : IUpdatable, IDrawable, IStartable<T>
    {
    }
}