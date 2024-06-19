using UnityEngine;

public class Fly : BaseMove
{
    public Fly() : base(new BaseParameters(1.3f)) { }

    public override void Move(Player player)
    {
        base.Move(player);
        player.transform.position = MoveToPositionY(player.transform);
        player.Animator.SetBool("grounded", false);
    }

    public virtual Vector3 MoveToPositionY(Transform transform)
    {
        return new Vector3(transform.position.x, 2, transform.position.z);
    }
}
