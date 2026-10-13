#region

using UnityEngine;
using UnityEngine.UI;

#endregion

[RequireComponent(typeof(Button))]
public class ToggleButton : MonoBehaviour
{
    [SerializeField] private Sprite _offStateSprite;
    [SerializeField] private Sprite _onStateSprite;

    [SerializeField] private bool _defaultState;
    private bool _currentState;
}