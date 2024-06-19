
using UnityEngine;

public class FastMove : BaseMove
{
    public FastMove() : base(5f) { }

    public override Vector3 MoveToPositionY(Transform transform)
    {
        return transform.position;
    }
}
