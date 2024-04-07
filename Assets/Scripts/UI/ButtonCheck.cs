using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCheck : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TMP_Text text;
    [SerializeField] private Image img;
    [SerializeField] private Color correctColor;
    [SerializeField] private Color initColor;

    private Action<string> _click;

    public string KeyActive { get; private set; }

    private void Start()
    {
        button.onClick.AddListener(() => _click(KeyActive));
    }

    private void OnDisable()
    {
        img.color = initColor;
        button.interactable = true;
        _click = null;
    }

    public void CheckCorrect()
    {
        img.color = correctColor;
        button.interactable = false;
    }

    public ButtonCheck SetKey(Node key)
    {
        KeyActive = key.Key;
        text.text = key.Valye;
        return this;
    }

    public void AddClick(Action<string> click) => _click += click;
}