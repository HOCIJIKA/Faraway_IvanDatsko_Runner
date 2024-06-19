
using UnityEngine;

public class SloveMove : IMovable   
{
    private readonly float _speed = 0.3f;
    
    public void Move(Transform transform, Animator animator)
    {
        var vectorToMove = new Vector3(1, 0, 0) * Time.deltaTime * _speed;
        transform.Translate(vectorToMove);
        
        
        animator.SetBool("grounded", true);
    }
    
    public float GetSpeed()
    {
        return _speed;
    }

    public Vector3 MoveToPositionY(Transform transform)
    {
        return new Vector3(transform.position.x, 0, transform.position.z);
    }
}
