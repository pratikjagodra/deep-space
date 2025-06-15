using UnityEngine;

namespace DeepSpace.UI
{
    public class Joystick : MonoBehaviour
    {
        [SerializeField] private RectTransform joystick;
        [SerializeField] private RectTransform joystickBg;
        [SerializeField] private RectTransform joystickCenter;
        [SerializeField] private RectTransform joystickBound;
        [SerializeField] private RectTransform canvas;

        private Vector2 startPos = Vector2.zero;
        private Vector2 curPos = Vector2.zero;
        private Vector2 direction = Vector2.zero;
        private Vector2 unitDirection = Vector2.zero;

        private float canvasScale;
        private float maxDirection;
        private float sqMaxDirection;
        private float directionScale;

        private void Start()
        {
            canvasScale = canvas.localScale.x;
            maxDirection = joystickBound.rect.height / 2;
            sqMaxDirection = maxDirection * maxDirection;
            OnTouchUp();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnTouchDown();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                OnTouchUp();
            }

            if (Input.GetMouseButton(0))
            {
                curPos = Input.mousePosition;
                direction = (curPos - startPos) / canvasScale;

                // float angle = Mathf.Atan2(direction.y, direction.x);
                // directionScale = direction.y / Mathf.Sin(angle);

                // if (directionScale > maxDirection)
                // {
                //     direction = (direction / directionScale) * maxDirection;
                // }

                if (direction.sqrMagnitude > sqMaxDirection)
                    direction = direction.normalized * maxDirection;

                unitDirection = direction / maxDirection;

                joystickCenter.anchoredPosition = direction;
            }
        }

        private void OnTouchDown()
        {
            startPos = Input.mousePosition;
            curPos = startPos;

            joystick.anchoredPosition = startPos / canvasScale;

            joystickBg.gameObject.SetActive(true);
            joystickCenter.gameObject.SetActive(true);
        }

        private void OnTouchUp()
        {
            startPos = Vector2.zero;
            curPos = Vector2.zero;
            direction = Vector2.zero;
            unitDirection = Vector2.zero;

            joystickBg.gameObject.SetActive(false);
            joystickCenter.anchoredPosition = direction;
            joystickCenter.gameObject.SetActive(false);

            joystick.anchorMax = Vector2.zero;
            joystick.anchorMin = Vector2.zero;
        }

        public float Horizontal()
        {
            return unitDirection.x;
        }

        public float Vertical()
        {
            return unitDirection.y;
        }

        public Vector2 UnitRawDirection()
        {
            return unitDirection;
        }
    }
}

