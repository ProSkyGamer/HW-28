#region

using UnityEngine;

#endregion

public class TimerTest : MonoBehaviour
{
    [SerializeField] private float _timerTime;

    [SerializeField] private Transform _uiContainer;
    [SerializeField] private Transform _uiPosition;
    [SerializeField] private TimerUI _timerUIPrefab;

    private Timer.Timer _timer;

    private void Awake()
    {
        _timer = new Timer.Timer(_timerTime, this);

        InitializeUI();
    }

    private void InitializeUI()
    {
        TimerUI timerUI = Instantiate(_timerUIPrefab, _uiPosition.position, Quaternion.identity, _uiContainer);
        timerUI.Initialize(_timer);
    }
}