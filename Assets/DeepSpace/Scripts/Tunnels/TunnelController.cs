using DeepSpace.Managers;
using UnityEngine;

namespace DeepSpace.Tunnels
{
    public class TunnelController : MonoBehaviour
    {
        [SerializeField] private Tunnel[] tunnels;
        [SerializeField] private float tunnelMoveSpeed = 10f;
        
        private bool canMoveTunnels = false;

        private void OnEnable()
        {
            GameManager.OnGameStart += StartMovingTunnels;
            GameManager.OnGameEnd += StopMovingTunnels;
        }

        private void OnDisable()
        {
            GameManager.OnGameStart -= StartMovingTunnels;
            GameManager.OnGameEnd -= StopMovingTunnels;
        }

        void Update()
        {
            if (!canMoveTunnels) return;
            MoveTunnels(Time.deltaTime);
        }

        private void MoveTunnels(float deltaTime)
        {
            for (int i = 0; i < tunnels.Length; i++)
            {
                tunnels[i].Move(tunnelMoveSpeed, deltaTime);
            }
        }

        private void StartMovingTunnels()
        {
            SetUpTunnels();
            canMoveTunnels = true;
        }

        private void StopMovingTunnels()
        {
            canMoveTunnels = false;
        }

        private void SetUpTunnels()
        {
            for (int i = 0; i < tunnels.Length; i++)
            {
                tunnels[i].SetUp(i, tunnels.Length);
            }
        }
    }
}
