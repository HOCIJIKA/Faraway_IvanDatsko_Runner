using UnityEngine;

public class Fly : BaseMove
{
    public Fly() : base(new BaseParameters(1.3f)) { }

    public override void Move(Player player)
    {
        player.transform.position = MoveToPositionY(player.transform);
        var vectorToMove = new Vector3(1, 0, 0) * Time.deltaTime * _parameters.Speed;
        player.transform.Translate(vectorToMove);
    }

    public virtual Vector3 MoveToPositionY(Transform transform)
    {
        return new Vector3(transform.position.x, 2, transform.position.z);
    }
}
