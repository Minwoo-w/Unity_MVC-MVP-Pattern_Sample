namespace Dev.Scripts.IdleGame
{
    public class IdleGameController
    {
        private readonly IIdleGameView _gameView;
        
        private IdleGameCharacter _character;
        
        public IdleGameController(IIdleGameView gameView)
        {
            _gameView = gameView;
            _character = new IdleGameCharacter(50.0f, 1.0f);

            _character.OnChangedHealth += UpdateHealth;
            _character.OnHit += OnHitFromCharacter;
            _character.OnDead += OnDeadFromCharacter;
            UpdateHealth(_character.GetCurrentHealth(), _character.GetMaxHealth());
        }

        public void ApplyDamage(float value)
        {
            _character.ApplyDamage(value);
        }
        
        private void UpdateHealth(float currentHealth, float maxHealth)
        {
            _gameView.OnUpdateHealth(currentHealth, maxHealth);
        }
        
        private void OnHitFromCharacter(float value)
        {
            _gameView.OnHit(value);
        }
        
        private void OnDeadFromCharacter()
        {
            _gameView.OnDead();
        }
    }
}