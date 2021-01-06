using System;

namespace GameMAQ.Lib.Components.Colliders
{
    public abstract class Collider<T> : Component where T : class
    {
        public event Action<T> CollideEvent;

        public event Action<T> EnterEvent;

        public event Action<T> ExitEvent;

        public abstract bool IsColliding(T col);

        public virtual void OnCollide(T col)
        {
            CollideEvent?.Invoke(col);
        }

        public virtual void OnEnter(T col)
        {
            EnterEvent?.Invoke(col);
        }

        public virtual void OnExit(T col)
        {
            ExitEvent?.Invoke(col);
        }
    }

    public abstract class Collider : Collider<Collider>
    {
    }
}