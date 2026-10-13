#region

using UnityEngine;
using UnityEngine.UI;

#endregion

public class SliderTimerUI : TimerUI
{
    [SerializeField] private Slider _slider;

    protected override void InitializeUIInternal()
    {
        _slider.minValue = 0f;
        _slider.maxValue = 1f;

        _slider.enabled = false;

        SetSliderValue(Timer.TotalTime, Timer.TimeLeft);
    }

    protected override void Timer_OnTimerUpdated()
    {
        SetSliderValue(Timer.TotalTime, Timer.TimeLeft);
    }

    private void SetSliderValue(float totalTime, float timeLeft)
    {
        _slider.value = timeLeft / totalTime;
    }
}