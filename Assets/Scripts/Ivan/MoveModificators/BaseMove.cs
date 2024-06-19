using UnityEngine;

public abstract class BaseMove : IMovable
{
    private readonly float _speed;

    protected BaseMove(float speed)
    {
        _speed = speed;
    }

    public virtual void Move(Player player)
    {
        var vectorToMove = new Vector3(1, 0, 0) * Time.deltaTime * _speed;
        player.transform.Translate(vectorToMove);

        player.Animator.SetBool("grounded", true);
    }

    public abstract Vector3 MoveToPositionY(Transform transform);
}
