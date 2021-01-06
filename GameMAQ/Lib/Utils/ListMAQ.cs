using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GameMAQ.Lib.Utils
{
    public class ListMAQ<T> : Collection<T>
    {
        public delegate void AddHandler(ListMAQ<T> collection, T newItem);

        public event AddHandler BeforeAdding;

        public event AddHandler AfterAdding;

        public ListMAQ() : base(new List<T>())
        {
        }

        public new void Add(T item)
        {
            BeforeAdding?.Invoke(this, item);
            base.Add(item);
            AfterAdding?.Invoke(this, item);
        }

        public new void Insert(int index, T item)
        {
            BeforeAdding?.Invoke(this, item);
            base.Insert(index, item);
            AfterAdding?.Invoke(this, item);
        }
    }
}