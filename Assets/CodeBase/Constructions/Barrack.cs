using CodeBase.Constructions.SoldierBehaviors;
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
        private int _soldierMaxAmount;
        private bool _canSpawn;

        private void Awake()
        {
            _soldierSpawnPosition = GetComponentInChildren<SoldierSpawnPosition>();
        }

        private void Start()
        {
            _soldierMaxAmount = _barrackInformation.Level1Info.SoldierAmount;
            _spawnTimerMax = _barrackInformation.Level1Info.SpawnCooldown;
            CheckSoldierAmount();
        }

        private void Update()
        {
            HandleSpawning();
        }

        private void HandleSpawning()
        {
            if (_canSpawn)
            {
                _spawnTimer -= Time.deltaTime;

                if (!(_spawnTimer < 0f))
                    return;

                _spawnTimer += _spawnTimerMax;
                CreateSoldier();
                _soldierMaxAmount--;

                CheckSoldierAmount();
            }
        }

        private void CheckSoldierAmount() =>
            _canSpawn = _soldierMaxAmount != 0;

        private void CreateSoldier()
        {
            Soldier soldier = Instantiate(_soldier, _soldierSpawnPosition.transform.position,
                Quaternion.identity);
            soldier.StartPosition = _soldierSpawnPosition.transform;
            soldier.Died += AddVacation;
        }

        private void AddVacation()
        {
            _soldierMaxAmount++;
            CheckSoldierAmount();
        }
    }
}