using UnityEngine;

public class Fly : BaseMove
{
    public Fly() : base(new BaseParameters(1.3f)) { }

    public override void Move(Player player)
    {
        player.transform.position = MoveToPositionY(player.transform);
        base.Move(player);
    }

    public virtual Vector3 MoveToPositionY(Transform transform)
    {
        return new Vector3(transform.position.x, 2, transform.position.z);
    }
}
