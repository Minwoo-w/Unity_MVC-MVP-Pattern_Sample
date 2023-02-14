using System;
using UnityEngine;

namespace Dev.Scripts.IdleGame
{
    public class IdleGameManager : MonoBehaviour
    {
        [SerializeField] private IdleGameCharacterView idleGameCharacterView;
        private IdleGameController _idleGameController;

        private void Awake()
        {
            _idleGameController = new IdleGameController(idleGameCharacterView);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _idleGameController.ApplyDamage(1.0f);
            }
        }
    }
}