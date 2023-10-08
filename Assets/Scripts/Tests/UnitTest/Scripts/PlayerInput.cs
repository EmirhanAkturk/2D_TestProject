using UnityEngine;

namespace Tests.UnitTest.Scripts
{
    public class PlayerInput : IPlayerInput
    {
        public float Verticle => Input.GetAxis("Vertical");
    }
}
