#region

using System.Collections.Generic;
using UnityEngine;

#endregion

public class HeartsTimerUI : TimerUI
{
    [SerializeField] private Transform _heartPrefab;
    [SerializeField] private Transform _heartsContainer;
    private List<Transform> _hearts = new();

    protected override void InitializeUIInternal()
    {
        SetTime(Timer.TimeLeft);
    }

    protected override void Timer_OnTimerUpdated(float value)
    {
        SetTime(value);
    }

    private void SetTime(float currentTime)
    {
        foreach (Transform toDelete in _hearts)
        {
            if (toDelete != _heartsContainer)
                Destroy(toDelete.gameObject);
        }
        _hearts.Clear();

        for (int i = 0; i < currentTime; i++)
        {
            Transform newHeart = Instantiate(_heartPrefab, _heartsContainer);
            _hearts.Add(newHeart);
        }
    }
}