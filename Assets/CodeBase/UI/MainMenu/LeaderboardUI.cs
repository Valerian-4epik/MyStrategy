using UnityEngine;

namespace CodeBase.UI.MainMenu
{
    public class LeaderboardUI : MonoBehaviour
    {
        [SerializeField] private GameObject _leaderboardPanel;
        
        public void OpenPanel()
        {
            _leaderboardPanel.gameObject.SetActive(true);
        }
    }
}