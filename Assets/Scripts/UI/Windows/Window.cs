using Extension.Attribute;
using UnityEngine;

namespace UI.Windows
{
    public class Window : MonoBehaviour
    {
        [SerializeField] private bool isStartOpen;

        [SerializeField, DropDownListString("WindowListSetting")]
        private string nameWindow;

        private bool _isOpen;

        public bool IsOpen
        {
            get => _isOpen;
            set => _isOpen = value;
        }

        private void Awake()
        {
            _isOpen = isStartOpen;
        }

        public bool IsName(string name) => nameWindow == name;

        public void Open() => gameObject.SetActive(_isOpen);
    }
}