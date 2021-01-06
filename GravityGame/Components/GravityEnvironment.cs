using GameMAQ.Lib;

namespace GravityGame.Components
{
    internal class GravityEnvironment : Component
    {
        public override void Update()
        {
            base.Update();
            foreach (var child1 in GameObject.Children)
            {
                foreach (var child2 in GameObject.Children)
                {
                    if (!child1.Equals(child2))
                    {
                    }
                }
            }
        }
    }
}