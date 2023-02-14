using UnityEngine;
using UnityEngine.UI;

namespace Dev.Scripts.IdleGame
{
    public class IdleGameCharacterView : MonoBehaviour, IIdleGameView
    {
        private static readonly int HitAnimationHashID = Animator.StringToHash("hit");
        private static readonly int IsDeadAnimationHashID = Animator.StringToHash("isDead");

        [SerializeField] private Text healthText;
        [SerializeField] private Animator characterAnimator;

        public void OnUpdateHealth(float currentHealth, float maxHealth)
        {
            if (healthText != null) healthText.text = $"{currentHealth} / {maxHealth}";
        }

        public void OnHit(float value)
        {
            if (characterAnimator != null) characterAnimator.SetTrigger(HitAnimationHashID);
        }

        public void OnDead()
        {
            if (characterAnimator != null) characterAnimator.SetBool(IsDeadAnimationHashID, true);
        }
    }
}