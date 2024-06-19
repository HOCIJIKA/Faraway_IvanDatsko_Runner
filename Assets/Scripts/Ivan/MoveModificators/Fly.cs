using UnityEngine;

public class Fly : BaseMove
{
    
    public Fly() : base(new BaseParameters(1.3f)) { }

    public override void Move(Player player)
    {
        player.transform.position = MoveToPositionY(player.transform);
        
        Vector2 vectorToMove = Vector2.right * _parameters.Speed * Time.fixedDeltaTime;
        player.Rigidbody2D.MovePosition(player.Rigidbody2D.position + vectorToMove);
    }

    public virtual Vector3 MoveToPositionY(Transform transform)
    {
        return new Vector3(transform.position.x, 2, transform.position.z);
    }
}
