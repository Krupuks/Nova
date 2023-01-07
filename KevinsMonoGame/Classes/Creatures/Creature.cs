using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KevinsMonoGame
{
    internal abstract class Creature : Entity, IPolyMorph, IRigid, IMovable, IAnimatable, ICanRunAnimated, ICanCrouchRunAnimated, ICanAttackAnimated, ICanCrouchAnimated, ICanJumpAnimated
    {
        //ISolid
        public CollisionDetector CollisionDetector { get; set; } = new CollisionDetector();
        public Collider ColliderIdle { get; set; } = new Collider();
        //IPolymorph
        public ColliderManager ColliderManager { get; set; } = new ColliderManager();
        public Collider ActiveCollider { get; set; } = new Collider();


        //IRigid
        public Gravity Gravity { get; set; } = new Gravity();
        public Collider GroundCheck { get; set; } = new Collider();
        public bool IsFalling { get; set; } = false;
        public float Mass { get; set; } = 20f;

        //IMovable
        public Movement Movement { get; set; } = new Movement();
        public Vector2 Direction { get; set; } = Vector2.Zero;
        public Vector2 Speed { get; set; } = new Vector2(20, 25);
        public Vector2 Acceleration { get; set; }


        //ICanDie
        public bool IsAlive { get; set; } = true;
        public DeathManager DeathManager { get; set; } = new DeathManager();
        public HealthManager HealthManager { get; set; } = new HealthManager();
        public HealthBar HealthBar { get; set; }
        public float MaxHealth { get; set; } = 100;
        public float CurrentHealth { get; set; } = 100;


        //IAnimatable
        public AnimationManager AnimationManager { get; set; } = new AnimationManager();
        public Animation AnimationIdle { get; set; } = new Animation();

        //ICanAttack(Animated)
        public bool IsAttacking { get; set; } = false;
        public Collider ColliderAttack { get; set; } = new Collider();
        public Collider ColliderWeapon { get; set; } = new Collider();
        public Texture2D TextureAttack { get; set; } = null;
        public Animation AnimationAttack { get; set; } = new Animation();

        //ICanCrouch(Animated)
        public bool IsCrouching { get; set; } = false;
        public Collider ColliderCrouch { get; set; } = new Collider();
        public Texture2D TextureCrouch { get; set; } = null;
        public Animation AnimationCrouch { get; set; } = new Animation();

        //ICanRun(Animated)
        public bool IsIdle { get; set; } = true;
        public Collider ColliderRun { get; set; } = new Collider();
        public Texture2D TextureRun { get; set; } = null;
        public Animation AnimationRun { get; set; } = new Animation();

        //IcanCrouchRun(Animated)
        public Collider ColliderCrouchRun { get; set; } = new Collider();
        public Texture2D TextureCrouchRun { get; set; } = null;
        public Animation AnimationCrouchRun { get; set; } = new Animation();

        //IcanJump(Animated)
        public bool IsJumping { get; set; } = false;
        public Collider ColliderJump { get; set; } = new Collider();
        public Texture2D TextureJump { get; set; } = null;
        public Animation AnimationJump { get; set; } = new Animation();



        public override void Update(GameTime gameTime){}
        public override void Draw(SpriteBatch spriteBatch){}

    }
}
