using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeBase.UI.MainMenu
{
    public class LevelSelectMenuUI : MonoBehaviour
    {
        [SerializeField] private GameObject _levelSelectPanel;
        [SerializeField] private Button _level_1_StartButton;
        [SerializeField] private Button _level_2_StartButton;
        [SerializeField] private Button _level_3_StartButton;

        private void Start()
        {
            _level_1_StartButton.onClick.AddListener(PlayGame);
        }

        public void OpenPanel()
        {
            _levelSelectPanel.gameObject.SetActive(true);
        }

        private void PlayGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}