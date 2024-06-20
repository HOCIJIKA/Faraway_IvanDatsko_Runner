using UnityEngine;

public abstract class BaseMove : IMovable
{
    protected readonly BaseParameters _parameters;

    protected BaseMove(BaseParameters parameters)
    {
        _parameters = parameters;
    }

    public virtual void Move(Player player)
    {
        Vector2 currentVelocity = player.Rigidbody2D.velocity;
        Vector2 targetVelocity = new Vector2(_parameters.Speed, currentVelocity.y);
        player.Rigidbody2D.velocity = targetVelocity;
        player.Rigidbody2D.isKinematic = false;
        
        if (player.IsJump && player.IsGrounded )
        {
            Jump(player.Rigidbody2D);
        }
    }
    
    private void Jump(Rigidbody2D rigidbody2D)
    {
        rigidbody2D.AddForce(new Vector2(0f, 5), ForceMode2D.Impulse);
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
