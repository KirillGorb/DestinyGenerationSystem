using System.Collections.Generic;
using Extension.Attribute;
using UnityEngine;

namespace UI.Windows
{
    public class WindowAggregator : MonoBehaviour
    {
        [SerializeField] private List<Window> windows;

        [SerializeField, DropDownListString("WindowListSetting")]
        private string initWindowName;

        private void Start()
        {
            Open(initWindowName);
        }

        public void Open(Window window)
        {
            foreach (var item in windows)
            {
                item.IsOpen = item.Equals(window);
                item.Open();
            }
        }

        public void Open(string key)
        {
            foreach (var item in windows)
            {
                item.IsOpen = item.IsName(key);
                item.Open();
            }
        }
    }
}