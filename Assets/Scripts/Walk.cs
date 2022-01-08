using UnityEngine;

namespace DefaultNamespace
{
    public class Walk : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float speed = 1;
        [SerializeField] private float jumpSpeed = 1;
        [SerializeField] private float gravity = 9.8f;
        [SerializeField] private float terminalVerticalVelocity = 100.0f;
        
        private float _verticalVelocity;

        private void Update()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            var tr = transform;

            _verticalVelocity = Mathf.Clamp(_verticalVelocity, -terminalVerticalVelocity, terminalVerticalVelocity); 
            
            var movement =
                (tr.right * horizontal + tr.forward * vertical) * speed + // left/right, front/back
                _verticalVelocity * Vector3.down; // gravity
            
            characterController.Move(movement * Time.deltaTime);
            
            // characterController.
            
            if (!characterController.isGrounded)
                _verticalVelocity += gravity * Time.deltaTime;
            else
            {
                _verticalVelocity = 2f;
                if (Input.GetButtonDown("Jump"))
                    _verticalVelocity -= jumpSpeed;
            }
        }
    }
}