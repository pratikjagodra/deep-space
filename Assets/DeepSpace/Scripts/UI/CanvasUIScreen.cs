using EasyHelpers.Runtime.Tools.ScreenService;
using UnityEngine;

namespace DeepSpace.UI
{
    [RequireComponent(typeof(Canvas))]
    public class CanvasUIScreen : UIScreen
    {
        private Canvas canvas;

        protected virtual void Awake()
        {
            canvas = GetComponent<Canvas>();
        }

        public override void OnShowScreen()
        {
            canvas.enabled = true;
        }

        public override void OnHideScreen()
        {
            canvas.enabled = false;
        }
    }
}
