using UnityEngine;

namespace CodeBase.UI.MainMenu
{
    public class OptionsUI : MonoBehaviour
    {
        [SerializeField] private GameObject _optionsPanel;

        public void OpenPanel()
        {
            _optionsPanel.gameObject.SetActive(true);
        }
    }
}