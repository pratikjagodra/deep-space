using System;
using DeepSpace.UI;
using EasyHelpers.Runtime.Common;
using EasyHelpers.Runtime.Tools.ScreenService;

namespace DeepSpace.Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        internal static Action OnGameStart;
        internal static Action OnGameEnd;

        protected override void Awake()
        {
            base.Awake();
            SetFPS.Set(60);
        }

        internal void StartGame()
        {
            ScreenService.Instance.HideScreen<MainMenuScreen>();
            ScreenService.Instance.ShowScreen<ShipInputScreen>();
            OnGameStart?.Invoke();
        }

        internal void EndGame()
        {
            OnGameEnd?.Invoke();
        }
    }
}
