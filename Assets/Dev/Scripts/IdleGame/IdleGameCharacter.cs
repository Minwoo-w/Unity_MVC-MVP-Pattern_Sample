using System;

namespace Dev.Scripts.IdleGame
{
    public class IdleGameCharacter
    {
        private bool _isAlive;
        private float _maxHealth;
        private float _currentHealth;
        private float _damage;

        public event Action<float, float> OnChangedHealth;
        public event Action OnDead;
        
        public IdleGameCharacter(float health, float damage)
        {
            _isAlive = true;
            
            _maxHealth = health;
            _currentHealth = _maxHealth;

            _damage = damage;
        }
        
        public float GetCurrentHealth()
        {
            return _currentHealth;
        }
        
        public float GetMaxHealth()
        {
            return _maxHealth;
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
            OnChangedHealth?.Invoke(_currentHealth, _maxHealth);
            
            if (_currentHealth == 0.0f)
            {
                Dead();
            }
        }

        public void RecoveryHealth(float value)
        {
            _currentHealth += value;
            if (_currentHealth > _maxHealth) _currentHealth = _maxHealth;
            OnChangedHealth?.Invoke(_currentHealth, _maxHealth);
        }
    }
}