using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMove : BaseMove
{
    public DefaultMove() : base(1f) { }

    public override void Move(Transform transform, Animator animator)
    {
        base.Move(transform, animator);
        animator.SetBool("grounded", true);
    }
    
    public override Vector3 MoveToPositionY(Transform transform)
    {
        return transform.position;
    }
}
