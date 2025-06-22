using UnityEngine;
using TMPro;
using DeepSpace.UI;

namespace DeepSpace.Utils
{
    public class FPSCounter : CanvasUIScreen
    {
        [SerializeField] private TMP_Text fpsText;

        private int fps = 0;
        private float time = 0f;

        private void Update()
        {
            if (time < 1)
            {
                time += Time.deltaTime;
                fps += 1;
            }
            else
            {
                fpsText.text = fps.ToString();
                fps = 0;
                time = 0f;
            }
        }
    }
}
