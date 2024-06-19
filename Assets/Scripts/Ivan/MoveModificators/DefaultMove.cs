using UnityEngine;

public class DefaultMove : BaseMove
{
    public DefaultMove() : base(1f) { }

    public override void Move(Player player)
    {
        base.Move(player);
        player.Animator.SetBool("grounded", true);
    }
    
    public override Vector3 MoveToPositionY(Transform transform)
    {
        return transform.position;
    }
}
