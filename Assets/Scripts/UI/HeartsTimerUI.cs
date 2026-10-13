#region

using UnityEngine;

#endregion

public class HeartsTimerUI : TimerUI
{
    [SerializeField] private Transform _heartPrefab;
    [SerializeField] private Transform _heartsContainer;

    protected override void InitializeUIInternal()
    {
        SetTime(Timer.TimeLeft);
    }

    protected override void Timer_OnTimerUpdated()
    {
        SetTime(Timer.TimeLeft);
    }

    private void SetTime(float currentTime)
    {
        foreach (Transform toDelete in _heartsContainer.GetComponentsInChildren<Transform>())
        {
            if (toDelete != _heartsContainer)
                Destroy(toDelete.gameObject);
        }

        for (int i = 0; i < currentTime; i++)
        {
            Transform newHeart = Instantiate(_heartPrefab, _heartsContainer);
        }
    }
}