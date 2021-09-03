using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Common
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private DateTime _endTime;
        private TimeSpan RemainingTime => _endTime - DateTime.Now;

        public UnityAction Finished;

        public void Init(DateTime endTime)
        {
            _endTime = endTime;
        }

        private void Update()
        {
            if (RemainingTime.Ticks <= 0)
            {
                Finished?.Invoke();
                _text.text = TimeFormatter.DateToText(TimeSpan.Zero);

                return;
            }

            _text.text = TimeFormatter.DateToText(_endTime - DateTime.Now);
        }
    }
}