using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float RayLength = 0.45f;

    [SerializeField] private LayerMask _groundLayer;

    public Animator Animator { get; private set; }
    public Rigidbody2D Rigidbody2D { get; private set; }
    
    private bool _isGrounded { get; set; }
    private bool isStarted { get; set; }
    private IMovable _movable { get; set; }
    private Coroutine _currentBuffDurationRoutine { get; set; }
    
    private void Awake()
    {
        Animator = GetComponent<Animator>();
        _movable = new DefaultMove();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    { 
        StartCoroutine(DelayToRun());
    }

    private void FixedUpdate()
    {
        if (!isStarted)
        {
            Animator.SetBool("grounded", false);
            Animator.SetFloat("velocityX", 1);
            return;
        }
        
        CheckGround();
        Animator.SetBool("grounded", _isGrounded);
        Animator.SetFloat("velocityX", 1);
        
        _movable.Move(this);
    }

    public void AddBuff(IMovable movableType, float duration)
    {
        if (_currentBuffDurationRoutine != default)
        {
            StopCoroutine(_currentBuffDurationRoutine);
        }
        
        _movable = movableType;
        _currentBuffDurationRoutine = StartCoroutine(ResetToDefaultAfter(duration));
    }
    
    private void CheckGround()
    {
        Vector2 direction = Vector2.down;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, RayLength, _groundLayer);
        _isGrounded = hit.collider != null;
    }
    
    private IEnumerator ResetToDefaultAfter(float duration)
    {
        yield return new WaitForSeconds(duration);
        _movable = new DefaultMove();
    }

    private IEnumerator DelayToRun()
    {
        yield return new WaitForSeconds(1);
        isStarted = true;
    }

}
