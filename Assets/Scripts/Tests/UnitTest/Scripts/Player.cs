using System;
using UnityEngine;

namespace Tests.UnitTest.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
        private Rigidbody rb;
        
        public IPlayerInput PlayerInput { get; set; }

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
        }

        private void Update()
        {
            float vertical = PlayerInput.Verticle;
            float moveSpeed = 100f;
            rb.AddForce(0, 0, vertical * moveSpeed);
        }
    }

}
