using System.Collections.Generic;
using GameMAQ.Lib.Components;
using GameMAQ.Lib.Utils;

namespace GameMAQ.Lib
{
    public class GameObject : IRenderable<GameMAQ>
    {
        private List<float> test = new List<float>();

        public GameObject Parent { get; set; }

        public GameMAQ Game { get; set; }

        public Transform Transform { get; set; }

        public ListMAQ<Component> Components { get; set; }

        public ListMAQ<GameObject> Children { get; set; }

        public GameObject()
        {
            Transform = new Transform();
            Children = new ListMAQ<GameObject>();
            Components = new ListMAQ<Component>();
            Children.BeforeAdding += ChildrenOnBeforeAdding;
            Components.BeforeAdding += ComponentsOnBeforeAdding;

            Components.Add(Transform);
        }

        private void ComponentsOnBeforeAdding(ListMAQ<Component> collection, Component newItem)
        {
            newItem.GameObject = this;
        }

        private void ChildrenOnBeforeAdding(ListMAQ<GameObject> collection, GameObject newItem)
        {
            newItem.Parent = this;
            newItem.Game = Game;
        }

        public IEnumerable<T> GetComponents<T>() where T : Component
        {
            foreach (var component in Components)
            {
                if (component is T != false) yield return component as T;
            }
        }

        public IEnumerable<T> GetComponentsInTree<T>() where T : Component
        {
            var comps = new List<T>();
            comps.AddRange(GetComponents<T>());
            foreach (var child in Children)
            {
                var obj = child;
                comps.AddRange(obj.GetComponentsInTree<T>());
            }
            return comps;
        }

        public void Draw()
        {
            for (int i = 0; i < Components.Count; i++)
            {
                Components[i].Draw();
            }
            for (int i = 0; i < Children.Count; i++)
            {
                Children[i].Draw();
            }

            test.Add(Transform.AbsolutePosition.X);
        }

        public void Update()
        {
            for (int i = 0; i < Children.Count; i++)
            {
                Children[i].Update();
            }

            for (int i = 0; i < Components.Count; i++)
            {
                Components[i].Update();
            }
        }

        public void Initialize(GameMAQ game)
        {
            Game = game;
            for (int i = 0; i < Components.Count; i++)
            {
                Components[i].Initialize(this);
            }
            for (int i = 0; i < Children.Count; i++)
            {
                Children[i].Initialize(Game);
                Children[i].Parent = this;
            }
        }

        public void Start()
        {
            for (int i = 0; i < Components.Count; i++)
            {
                Components[i].Start();
            }
            for (int i = 0; i < Children.Count; i++)
            {
                Children[i].Start();
            }
        }
    }
}