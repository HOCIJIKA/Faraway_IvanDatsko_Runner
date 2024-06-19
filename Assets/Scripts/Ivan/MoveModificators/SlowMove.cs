
using UnityEngine;

public class SlowMove : BaseMove
{
    public SlowMove() : base(0.3f) { }

    public override Vector3 MoveToPositionY(Transform transform)
    {
        return new Vector3(transform.position.x, 0, transform.position.z);
    }
}
