
using UnityEngine;

public class Fly : IMovable   
{
    private readonly float _speed = 1.3f;
    
    public void Move(Transform transform, Animator animator)
    {
        var vectorToMove = new Vector3(1, 0, 0) * Time.deltaTime * _speed;
        transform.Translate(vectorToMove);

        transform.position = MoveToPositionY(transform);
        
        animator.SetBool("grounded", false);
    }
    
    public float GetSpeed()
    {
        return _speed;
    }

    public Vector3 MoveToPositionY(Transform transform)
    {
        return new Vector3(transform.position.x, 2, transform.position.z);
    }
}
