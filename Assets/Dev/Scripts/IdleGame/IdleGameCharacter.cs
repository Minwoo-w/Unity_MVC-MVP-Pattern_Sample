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
        public event Action<float> OnHit;
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

        public void ApplyDamage(float value)
        {
            var restHealth = _currentHealth - value;
            
            OnHit?.Invoke(value);
            SetCurrentHealth(restHealth);
        }

        public void RecoveryHealth(float value)
        {
            var restHealth = _currentHealth + value;
            SetCurrentHealth(restHealth);
        }
        
        private void SetCurrentHealth(float value)
        {
            if (!_isAlive) return;
            
            _currentHealth = value;
            
            // Clamp Health
            if (_currentHealth < 0.0f) _currentHealth = 0.0f;
            else if (_currentHealth > _maxHealth) _currentHealth = _maxHealth;
            
            OnChangedHealth?.Invoke(_currentHealth, _maxHealth);
            
            if (_currentHealth == 0.0f)
            {
                Dead();
            }
        }
        
        private void Dead()
        {
            if (!_isAlive) return;
            
            _isAlive = false;
            _currentHealth = 0.0f;
            
            OnDead?.Invoke();
        }
    }
}