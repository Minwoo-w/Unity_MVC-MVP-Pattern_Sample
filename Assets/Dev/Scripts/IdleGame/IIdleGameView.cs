namespace Dev.Scripts.IdleGame
{
    public interface IIdleGameView
    {
        public void OnUpdateHealth(float currentHealth, float maxHealth);
        public void OnHit(float value);
        public void OnDead();
    }
}