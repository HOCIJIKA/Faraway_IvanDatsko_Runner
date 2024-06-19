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
        // var vectorToMove = new Vector3(1, 0, 0) * Time.deltaTime * _parameters.Speed;
        // player.transform.Translate(vectorToMove);
        
        //Vector2 vectorToMove = Vector2.right * _parameters.Speed * Time.fixedDeltaTime;
        Vector2 currentVelocity = player.Rigidbody2D.velocity;
        Vector2 targetVelocity = new Vector2(_parameters.Speed, currentVelocity.y);
        player.Rigidbody2D.velocity = targetVelocity;
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
