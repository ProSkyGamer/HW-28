#region

using UnityEngine;
using UnityEngine.UI;

#endregion

public abstract class TimerUI : MonoBehaviour
{
    [SerializeField] private Button _startTimer;
    [SerializeField] private Button _toggleTimer;
    [SerializeField] private Button _stopTimer;

    protected Timer.Timer Timer;

    public void Initialize(Timer.Timer timer)
    {
        Timer = timer;

        InitializeUI();

        Timer.TimerUpdated += Timer_OnTimerUpdated;
    }

    private void InitializeUI()
    {
        _startTimer.onClick.AddListener(StartTimerButtonClicked);
        _toggleTimer.onClick.AddListener(ToggleTimerButtonClicked);
        _stopTimer.onClick.AddListener(StopTimerButtonClicked);

        InitializeUIInternal();
    }

    protected abstract void InitializeUIInternal();

    protected abstract void Timer_OnTimerUpdated();

    private void StartTimerButtonClicked()
    {
        if (Timer.IsStarted)
            return;

        Timer.Start();

        UpdateTimerButtonAvailability();
    }

    private void ToggleTimerButtonClicked()
    {
        if (Timer.IsStarted == false)
            return;

        if (Timer.IsActive)
            Timer.Pause();
        else
            Timer.Resume();
    }

    private void StopTimerButtonClicked()
    {
        if (Timer.IsStarted == false)
            return;

        Timer.Stop();

        UpdateTimerButtonAvailability();
    }

    private void UpdateTimerButtonAvailability()
    {
        _startTimer.interactable = Timer.IsStarted == false;
        _toggleTimer.interactable = Timer.IsStarted;
        _stopTimer.interactable = Timer.IsStarted;
    }
}