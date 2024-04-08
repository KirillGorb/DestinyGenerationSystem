using System.Collections.Generic;
using Node;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class OutputResult : MonoBehaviour
    {
        [SerializeField] private CheckCorrect check;
        [SerializeField] private ListCorrect correct;
        [SerializeField] private Button checkResult;
        [SerializeField] private TMP_Text prefabResultText;
        [SerializeField] private Transform parentSpawn;

        private List<TMP_Text> _texts=new();

        private void Start()
        {
            checkResult.onClick.AddListener(PushButton);
        }

        private void PushButton()
        {
            int i = 0;
            foreach (var item in check.ActiveNames)
            {
                if (i > _texts.Count - 1)
                    _texts.Add(Instantiate(prefabResultText, parentSpawn));
                _texts[i++].text = correct.GetSequence(item).FinalDescription;
            }
        }
    }
}