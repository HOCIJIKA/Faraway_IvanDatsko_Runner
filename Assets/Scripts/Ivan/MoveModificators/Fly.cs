using UnityEngine;

public class Fly : BaseMove
{
    public Fly() : base(new BaseParameters(1f)) { }

    public override void Move(Player player)
    {
        base.Move(player);
        player.Rigidbody2D.isKinematic = true;
        player.transform.position = MoveToPositionY(player.transform);
    }

    private Vector3 MoveToPositionY(Transform transform)
    {
        return new Vector3(transform.position.x, 2, transform.position.z);
    }
}
