
using UnityEngine;

public class FastMove : IMovable   
{
    private readonly float _speed = 5f;
    
    public void Move(Transform transform, Animator animator)
    {
        var vectorToMove = new Vector3(1, 0, 0) * Time.deltaTime * _speed;
        transform.Translate(vectorToMove);
        
    }
    
    public float GetSpeed()
    {
        return _speed;
    }

    public Vector3 MoveToPositionY(Transform transform)
    {
        return transform.position;
    }
}
