using System;
using DeepSpace.Utils;
using UnityEngine;

namespace DeepSpace.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        internal static Action OnGameStart;
        internal static Action OnGameEnd;

        private void Start()
        {
            StartGame();
        }

        [ContextMenu(nameof(StartGame))]
        internal void StartGame()
        {
            OnGameStart?.Invoke();
        }

        [ContextMenu(nameof(EndGame))]
        internal void EndGame()
        {
            OnGameEnd?.Invoke();
        }
    }
}
