using UnityEngine;
using UnityEngine.UI;

namespace Dev.Scripts.IdleGame
{
    public class IdleMonsterCharacter : MonoBehaviour, IIdleGameView
    {
        private static readonly int IsDeadHashKey = Animator.StringToHash("isDead");
        
        [SerializeField] private Text healthText;
        [SerializeField] private Animator characterAnimator;

        public void OnUpdateHealth(float currentHealth, float maxHealth)
        {
            if (healthText != null) healthText.text = $"{currentHealth} / {maxHealth}";
        }

        public void OnDead()
        {
            if (characterAnimator != null) characterAnimator.SetBool(IsDeadHashKey, true);
        }
    }
}