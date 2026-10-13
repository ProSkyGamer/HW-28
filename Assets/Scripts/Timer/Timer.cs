#region

using System;
using System.Collections;
using UnityEngine;

#endregion

namespace Timer
{
    public class Timer
    {
        public event Action TimerUpdated;

        private Coroutine _timerCoroutine;
        private readonly MonoBehaviour _coroutineRunner;

        public bool IsActive => _timerCoroutine != null;
        public bool IsStarted { get; private set; }

        public float TimeLeft { get; private set; }
        public float TotalTime { get; }

        public Timer(float totalTime, MonoBehaviour coroutineRunner)
        {
            if (totalTime <= 0)
            {
                Debug.LogError("Timer cannot be less than 0!");

                return;
            }

            if (coroutineRunner == null)
            {
                Debug.LogError("Coroutine runner is null!");

                return;
            }

            TotalTime = totalTime;
            TimeLeft = TotalTime;
            _coroutineRunner = coroutineRunner;
        }

        public void Start()
        {
            IsStarted = true;

            TimeLeft = TotalTime;

            _timerCoroutine = _coroutineRunner.StartCoroutine(ProcessTimer());
        }

        public void Pause()
        {
            if (IsStarted == false)
                return;

            if (_timerCoroutine != null)
                _coroutineRunner.StopCoroutine(_timerCoroutine);

            _timerCoroutine = null;
        }

        public void Resume()
        {
            if (IsStarted == false)
                return;

            if (_timerCoroutine == null)
                _timerCoroutine = _coroutineRunner.StartCoroutine(ProcessTimer());
        }

        public void Stop()
        {
            if (IsStarted == false)
                return;

            if (_timerCoroutine != null)
                _coroutineRunner.StopCoroutine(_timerCoroutine);

            _timerCoroutine = null;

            IsStarted = false;
        }

        private IEnumerator ProcessTimer()
        {
            while (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;

                if (TimeLeft < 0f)
                    TimeLeft = 0f;

                TimerUpdated?.Invoke();

                yield return null;
            }
        }
    }
}