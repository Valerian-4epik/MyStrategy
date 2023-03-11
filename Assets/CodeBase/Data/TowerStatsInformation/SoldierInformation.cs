using UnityEngine;

namespace CodeBase.Data.TowerStatsInformation
{
    [CreateAssetMenu(fileName = "soldierInfo", menuName = "data/soldierInfo")]
    public class SoldierInformation : ScriptableObject
    {
        [SerializeField] private int _health;
        [SerializeField] private float _movementSpeed;

        public int Health => _health;
        public float MovementSpeed => _movementSpeed;
    }
}