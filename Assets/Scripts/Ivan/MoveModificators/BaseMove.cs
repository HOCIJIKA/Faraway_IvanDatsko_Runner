using UnityEngine;

public abstract class BaseMove : IMovable
{
    private readonly float _speed;

    protected BaseMove(float speed)
    {
        _speed = speed;
    }

    public virtual void Move(Transform transform, Animator animator)
    {
        var vectorToMove = new Vector3(1, 0, 0) * Time.deltaTime * _speed;
        transform.Translate(vectorToMove);

        animator.SetBool("grounded", true);
    }

    public abstract Vector3 MoveToPositionY(Transform transform);
}
