using System;
using System.Collections.Generic;

namespace GameMAQ.Lib.Components.Colliders
{
    public class ColliderManager : Component
    {
        private List<(Collider, Collider)> _lastState = new List<(Collider, Collider)>();

        public List<Collider> Colliders
        {
            get
            {
                return GameObject.GetComponentsInTree<Collider>() as List<Collider>;
            }
        }

        public List<(Collider, Collider)> CollidersTouching
        {
            get
            {
                var colliders = Colliders;
                var collidersPair = new List<(Collider, Collider)>();
                for (int i = 0; i < colliders.Count; i++)
                {
                    for (int j = i; j < colliders.Count; j++)
                    {
                        if (i != j && colliders[i].IsColliding(colliders[j]))
                        {
                            collidersPair.Add((colliders[i], colliders[j]));
                        }
                    }
                }
                return collidersPair;
            }
        }

        public override void Update()
        {
            base.Update();
            var touching = CollidersTouching;
            foreach (var pair in touching)
            {
                if (!_lastState.Contains(pair))
                {
                    pair.Item1.OnEnter(pair.Item2);
                    pair.Item2.OnEnter(pair.Item1);
                }
                else
                {
                    pair.Item1.OnCollide(pair.Item2);
                    pair.Item2.OnCollide(pair.Item1);
                    Console.WriteLine("Collide");
                }
            }
            foreach (var pair in _lastState)
            {
                if (!touching.Contains(pair))
                {
                    pair.Item1.OnExit(pair.Item2);
                    pair.Item2.OnExit(pair.Item1);
                }
            }

            _lastState = touching;
        }
    }
}