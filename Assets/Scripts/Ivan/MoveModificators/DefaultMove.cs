using UnityEngine;

public class DefaultMove : BaseMove
{
    public DefaultMove() : base(new BaseParameters(1)) { }

    public override void Move(Player player)
    {
        base.Move(player);
        player.Animator.SetBool("grounded", true);
    }
}
