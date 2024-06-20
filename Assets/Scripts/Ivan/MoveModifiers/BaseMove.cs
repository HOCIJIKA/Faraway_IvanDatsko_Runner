using UnityEngine;

namespace Ivan.MoveModifiers
{
    public abstract class BaseMove : IMovable
    {
        private const float BaseSpeed = 1.5f;
        private const float BaseJumpForce = 6f;
        protected readonly BaseParameters _parameters;

        protected BaseMove(BaseParameters parameters)
        {
            _parameters = parameters;
        }

        public virtual void Move(PlayerController playerController)
        {
            Vector2 currentVelocity = playerController.PlayerMovement.PlayerRigidbody.velocity;
            Vector2 targetVelocity = new Vector2(BaseSpeed * _parameters.Speed, currentVelocity.y);
            playerController.PlayerMovement.PlayerRigidbody.velocity = targetVelocity;
            playerController.PlayerMovement.PlayerRigidbody.isKinematic = false;
        
            if (playerController.PlayerMovement.IsJump && playerController.PlayerMovement.IsGrounded )
            {
                Jump(playerController.PlayerMovement.PlayerRigidbody);
                playerController.PlayerMovement.IsJump = false;
            }
        }
    
        private void Jump(Rigidbody2D rigidbody)
        {
            rigidbody.AddForce(new Vector2(0f, BaseJumpForce), ForceMode2D.Impulse);
            
        }

        protected struct BaseParameters
        {
            public readonly float Speed;

            public BaseParameters(float speed)
            {
                Speed = speed;
            }
        }
    }
}
