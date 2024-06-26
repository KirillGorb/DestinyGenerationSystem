﻿using System.Collections.Generic;
using System.Linq;
using Node;
using UnityEngine;

namespace UI
{
    public class CheckCorrect : MonoBehaviour
    {
        [SerializeField] private ListCorrect correct;
        [SerializeField] private View view;
        [SerializeField] private GameObject buttonCheckResult;

        private readonly List<string> _path = new();
        private readonly List<string> _nameActive = new();

        public IReadOnlyList<string> ActiveNames => _nameActive;

        private void OnEnable()
        {
            view.HandlingButtonStateAfterSpawning += CheckName;
            view.DataValidation += IsCorrect;
        }

        private void CheckName(ButtonCheck button)
        {
            foreach (var item in _nameActive)
                if (button.KeyActive == item)
                    button.CheckCorrect();

            buttonCheckResult.SetActive(_nameActive.Count > 0);
        }

        private void IsCorrect(string key)
        {
            _path.Add(key);
            var c = correct.GetSequence(_path.First());

            if (correct.GetSequence(key))
            {
                _path.Clear();
                _path.Add(key);
            }

            if (c && c.IsCorrect(_path))
                _nameActive.Add(_path.First());
        }
    }
}