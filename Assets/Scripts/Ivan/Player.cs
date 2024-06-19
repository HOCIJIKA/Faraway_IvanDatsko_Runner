using System.Collections;
using System.Net.NetworkInformation;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator Animator { get; set; }
    
    private bool _isGrounded = true;
    private bool isStarted = false;

    private IMovable _movable;

    private Coroutine _currentBuffDuration;
    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    private void Start()
    { 
        _movable = new DefaultMove();
        StartCoroutine(DelayToStart());
    }

    private void Update()
    {
        if (!isStarted)
        {
            Animator.SetBool("grounded", false);
            Animator.SetFloat("velocityX", 1);
            return;
        }
        
        _movable.Move(this);
    }

    public void AddBuff(IMovable movableType, float duration)
    {
        if (_currentBuffDuration != default)
        {
            StopCoroutine(_currentBuffDuration);
        }
        
        _movable = movableType;
        _currentBuffDuration = StartCoroutine(ResetToDefault(duration));
    }

    private IEnumerator ResetToDefault(float duration)
    {
        yield return new WaitForSeconds(duration);
        _movable = new DefaultMove();
    }

    private IEnumerator DelayToStart()
    {
        yield return new WaitForSeconds(1);
        isStarted = true;
    }

}
