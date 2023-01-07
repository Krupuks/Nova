
namespace KevinsMonoGame
{
    internal interface IPolyMorph : ISolid
    {
        public ColliderManager ColliderManager { get; set; }
        public Collider ActiveCollider { get; set; }
    }
}
