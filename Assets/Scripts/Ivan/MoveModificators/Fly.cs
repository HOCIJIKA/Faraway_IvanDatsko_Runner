
using UnityEngine;

public class Fly : BaseMove
{
    public Fly() : base(1.3f) { }

    public override void Move(Transform transform, Animator animator)
    {
        base.Move(transform, animator);
        transform.position = MoveToPositionY(transform);
        animator.SetBool("grounded", false);
    }

    public override Vector3 MoveToPositionY(Transform transform)
    {
        return new Vector3(transform.position.x, 2, transform.position.z);
    }
}
