namespace GameMAQ.Lib
{
    public abstract class Component : IRenderable<GameObject>
    {
        public GameObject GameObject { get; set; }

        public virtual void Update()
        {
        }

        public virtual void Draw()
        {
        }

        public virtual void Start()
        {
        }

        public virtual void Initialize(GameObject gobj)
        {
        }
    }
}