using UnityEngine;

public class BaseMove : IMovable
{
    private readonly float _speed = 1f;
    
    public void Move(Transform transform, Animator animator)
    {
        var vectorToMove = new Vector3(1, 0, 0) * Time.deltaTime * _speed;
        transform.Translate(vectorToMove);
        
        animator.SetBool("grounded", true);
        animator.SetFloat("velocityX", 1);
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
