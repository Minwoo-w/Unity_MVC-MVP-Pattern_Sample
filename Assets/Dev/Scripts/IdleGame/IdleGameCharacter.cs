using System;

namespace Dev.Scripts.IdleGame
{
    public class IdleGameCharacter
    {
        private bool _isAlive;
        private float _maxHealth;
        private float _currentHealth;

        public event Action<float> OnChangedHealth;
        public event Action OnDead;
        
        public IdleGameCharacter()
        {
            _isAlive = true;
            _maxHealth = 50.0f;
            _currentHealth = _maxHealth;
        }

        private void Dead()
        {
            if (!_isAlive) return;
            
            _isAlive = false;
            _currentHealth = 0.0f;
            
            OnDead?.Invoke();
        }

        public void ApplyDamage(float value)
        {
            _currentHealth -= value;
            if (_currentHealth < 0.0f) _currentHealth = 0.0f;
            OnChangedHealth?.Invoke(_currentHealth);
            
            if (_currentHealth == 0.0f)
            {
                Dead();
            }
        }

        public void RecoveryHealth(float value)
        {
            _currentHealth += value;
            if (_currentHealth > _maxHealth) _currentHealth = _maxHealth;
            OnChangedHealth?.Invoke(_currentHealth);
        }
    }
}