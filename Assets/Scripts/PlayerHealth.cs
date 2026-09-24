using System;
using UnityEngine;

namespace Game
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 100;

        public int CurrentHealth { get; private set; }
        public bool IsDead { get; private set; }

        public event Action Died;

        private void Awake()
        {
            CurrentHealth = maxHealth;
        }

        public void TakeDamage(int amount)
        {
            if (IsDead || amount <= 0)
                return;

            CurrentHealth = Mathf.Max(0, CurrentHealth - amount);

            if (CurrentHealth == 0)
            {
                IsDead = true;
                Died?.Invoke();
            }
        }

        public void Heal(int amount)
        {
            if (IsDead || amount <= 0)
                return;

            CurrentHealth = Mathf.Min(maxHealth, CurrentHealth + amount);
        }
    }
}
