#region

using TMPro;
using UnityEngine;

#endregion

public class TextTimerUI : TimerUI
{
    [SerializeField] private TextMeshProUGUI _timeLeft;
    [SerializeField] private float _timerPrecision;

    protected override void InitializeUIInternal()
    {
        SetTimerText(Timer.TimeLeft);
    }

    protected override void Timer_OnTimerUpdated(float value)
    {
        SetTimerText(value);
    }

    private void SetTimerText(float time)
    {
        int hoursLeft = (int)(time / (60 * 60));
        int minutesLeft = (int)(time % (60 * 60) / 60);
        float secondsLeft = time % 60;
        string secondLeftString = secondsLeft.ToString($"F{_timerPrecision}");
        _timeLeft.text = $"{hoursLeft}:{minutesLeft:00}:{secondLeftString}";
    }
}