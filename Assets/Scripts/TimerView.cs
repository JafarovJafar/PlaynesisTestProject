using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Common
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private DateTime _endTime;

        public void Init(DateTime endTime)
        {
            _endTime = endTime;
        }

        private void Update()
        {
            _text.text = TimeFormatter.DateToText(_endTime - DateTime.Now);
        }
    }
}