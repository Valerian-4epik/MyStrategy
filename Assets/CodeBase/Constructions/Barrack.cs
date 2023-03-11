using CodeBase.Data.TowerStatsInformation;
using CodeBase.Utilits;
using UnityEngine;

namespace CodeBase.Constructions
{
    public class Barrack : MonoBehaviour
    {
        [SerializeField] private BarrackInformation _barrackInformation;
        [SerializeField] private Soldier _soldier;

        private SoldierSpawnPosition _soldierSpawnPosition;
        private float _spawnTimerMax;
        private float _spawnTimer;

        private void Awake()
        {
            _soldierSpawnPosition = GetComponentInChildren<SoldierSpawnPosition>();
        }

        private void Start()
        {
            _spawnTimerMax = _barrackInformation.Level1Info.SpawnCooldown;
        }

        private void Update()
        {
            HandleSpawning();
        }

        private void HandleSpawning()
        {
            _spawnTimer -= Time.deltaTime;

            if (!(_spawnTimer < 0f))
                return;

            _spawnTimer += _spawnTimerMax;
            CreateSoldier();
        }

        private void CreateSoldier() =>
            Instantiate(_soldier, _soldierSpawnPosition.transform.position,
                Quaternion.identity);
    }
}