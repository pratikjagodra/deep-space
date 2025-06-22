using DeepSpace.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace DeepSpace.UI
{
    public class MainMenuScreen : CanvasUIScreen
    {
        [Space]
        [SerializeField] private Button startButton;

        protected override void Awake()
        {
            base.Awake();
            startButton?.onClick.AddListener(OnClickStartButton);
        }

        private void OnClickStartButton()
        {
            GameManager.Instance.StartGame();
        }
    }
}
