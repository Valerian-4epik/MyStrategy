using System;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.MainMenu
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _leaderboardButton;
        [SerializeField] private Button _optionsButton;

        private CanvasGroup _mainGroup;
        private LevelSelectMenuUI _levelSelectMenu;
        private LeaderboardUI _leaderboard;
        private OptionsUI _options;

        private void Awake()
        {
            _mainGroup = GetComponentInChildren<CanvasGroup>();
            _levelSelectMenu = GetComponent<LevelSelectMenuUI>();
            _leaderboard = GetComponent<LeaderboardUI>();
            _options = GetComponent<OptionsUI>();
        }

        private void Start()
        {
            _startButton.onClick.AddListener(OpenLevelSelectPanel);
            _leaderboardButton.onClick.AddListener(OpenLeaderboardPanel);
            _optionsButton.onClick.AddListener(OpenOptionsPanel);
        }

        private void OpenLevelSelectPanel()
        {
            _levelSelectMenu.OpenPanel();
            _mainGroup.alpha = 0;
        }

        private void OpenLeaderboardPanel()
        {
            _leaderboard.OpenPanel();
            _mainGroup.alpha = 0;
        }

        private void OpenOptionsPanel()
        {
            _options.OpenPanel();
            _mainGroup.alpha = 0;
        }
    }
}