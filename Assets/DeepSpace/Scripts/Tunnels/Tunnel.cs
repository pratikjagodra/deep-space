using DeepSpace.Utils;
using UnityEngine;

namespace DeepSpace.Tunnels
{
    public class Tunnel : MonoBehaviour
    {
        private int totalTunnelsCount;

        private bool IsOutOfRange()
        {
            return transform.position.z < -(Constants.TUNNEL_LENGTH * 1.5f);
        }

        private void SetAtEnd()
        {
            transform.position += totalTunnelsCount * Constants.TUNNEL_LENGTH * Vector3.forward;
        }

        internal void SetUp(int tunnelIndex, int tunnelsCount)
        {
            totalTunnelsCount = tunnelsCount;
            transform.position = Constants.TUNNEL_LENGTH * tunnelIndex * Vector3.forward;
        }

        internal void Move(float moveSpeed, float deltaTime)
        {
            transform.position -= moveSpeed * deltaTime * Vector3.forward;
            if (IsOutOfRange())
                SetAtEnd();
        }
    }
}
