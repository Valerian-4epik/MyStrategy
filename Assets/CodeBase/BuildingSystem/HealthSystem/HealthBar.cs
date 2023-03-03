using UnityEngine;
using UnityEngine.PlayerLoop;

namespace CodeBase.BuildingSystem.HealthSystem
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Transform _bar;

        private HealthSystem _healthSystem;

        public static bool operator +(HealthBar bar1, HealthBar bar2)
        {
            return bar1 != bar2;
        }
        
        private void Awake()
        {
            _healthSystem = GetComponentInParent<HealthSystem>();
        }

        private void Start()
        {
            _healthSystem.HealthChanged += UpdateBar;
            UpdateBar();
            UpdateHealthBarVisible();
        }

        private void UpdateBar()
        {
            _bar.localScale = new Vector3(_healthSystem.GetHealthAmountNormalized(), 1, 1);
            UpdateHealthBarVisible();
        }

        private void UpdateHealthBarVisible()
        {
            if (_healthSystem.IsFullHealth())
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
    }
}