using UnityEngine;

public abstract class BaseMove : IMovable
{
    private readonly BaseParameters _parameters;

    protected BaseMove(BaseParameters parameters)
    {
        _parameters = parameters;
    }

    public virtual void Move(Player player)
    {
        var vectorToMove = new Vector3(1, 0, 0) * Time.deltaTime * _parameters.Speed;
        player.transform.Translate(vectorToMove);

        player.Animator.SetBool("grounded", true);
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
