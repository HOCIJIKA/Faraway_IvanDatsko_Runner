using UnityEngine;

public interface IMovable
{
    void Move(Transform transform, Animator animator);
    
    float GetSpeed();

    Vector3 MoveToPositionY(Transform transform);
}
