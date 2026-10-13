#region

using UnityEngine;

#endregion

namespace Enemy
{
    public class Enemy : MonoBehaviour, IReadonlyEnemy
    {
        [SerializeField] private bool _isDead;
        // мне очень лень придумывать что-то еще, поэтому я просто сделаю это некрасиво

        public bool IsDead => _isDead;
    }
}