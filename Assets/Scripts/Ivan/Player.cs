using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    private bool _isGrounded = true;
    private bool isStarted = false;

    private IMovable _movable;

    private void Start()
    { 
        _movable = new DefaultMove();
        StartCoroutine(DelayToStart());
    }

    private void Update()
    {
        if (!isStarted)
        {
            _animator.SetBool("grounded", false);
            _animator.SetFloat("velocityX", 1);
            return;
        }
        
        _movable.Move(transform, _animator);
    }

    public void SetBuffType(IMovable movableType)
    {
        _movable = movableType;
    }

    private IEnumerator DelayToStart()
    {
        yield return new WaitForSeconds(1);
        isStarted = true;

        //StartCoroutine(ChangeMove());
    }

    /*private IEnumerator ChangeMove()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            _movable = new FastMove();
            Debug.LogWarning($"_movable: {_movable.GetType()}");
            
            yield return new WaitForSeconds(2);
            _movable = new Fly();
            Debug.LogWarning($"_movable: {_movable.GetType()}");

            
            yield return new WaitForSeconds(2);
            _movable = new SlowMove();
            Debug.LogWarning($"_movable: {_movable.GetType()}");

            
            yield return new WaitForSeconds(2);
            _movable = new DefaultMove();
            Debug.LogWarning($"_movable: {_movable.GetType()}");
            
        }
    }*/
}
