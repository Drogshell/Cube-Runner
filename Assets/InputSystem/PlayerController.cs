using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSystem
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float xClamp;
        [SerializeField] private float zClamp;
        
        private Vector2 _movement;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        private void FixedUpdate()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            var currentPosition = _rigidbody.position;
            var moveDirection = new Vector3(_movement.x, 0f, _movement.y);
            var newPosition = currentPosition + moveDirection * (moveSpeed * Time.fixedDeltaTime);

            newPosition.x = Mathf.Clamp(newPosition.x, -xClamp, xClamp);
            newPosition.z = Mathf.Clamp(newPosition.z, -zClamp, zClamp);
            
            _rigidbody.MovePosition(newPosition);
        }
        
        public void Move(InputAction.CallbackContext context)
        {
            _movement = context.ReadValue<Vector2>();
        }
    }
}
