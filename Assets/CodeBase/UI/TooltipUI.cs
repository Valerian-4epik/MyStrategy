using TMPro;
using UnityEngine;

namespace CodeBase.UI {
    public class TooltipUI : MonoBehaviour {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private RectTransform _backgroundRectTransform;

        private void Awake() {
            // _text = GetComponentInChildren<TextMeshPro>();
            // _backgroundRectTransform = GetComponentInChildren<RectTransform>();
            //
            SetText("hi there!");
        }

        private void SetText(string tooltipText) {
            _text.text = tooltipText;
            _text.ForceMeshUpdate();

            Vector2 textSize = _text.GetRenderedValues(false);
            _backgroundRectTransform.sizeDelta = new Vector2();
        }
    }
}