
namespace Assets.Scripts.Main.Models
{
    public class EnemyModel
    {
        public BaseView EnemyView;
        public EnemyState currentEnemyState;
        public float sqrDistance = 15*15;
        public float attackCooldown = 0.1f;
    }
}
