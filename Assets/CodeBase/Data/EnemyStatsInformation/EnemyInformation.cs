using UnityEngine;

namespace CodeBase.Data.EnemyStatsInformation
{
    [CreateAssetMenu(fileName = "enemyInfo", menuName = "data/enemyInfo")]
    public class EnemyInformation : ScriptableObject
    {
        [SerializeField] private int _health;
        [SerializeField] private float _movementSpeed;

        public int Health => _health;
        public float MovementSpeed => _movementSpeed;
    }
}
