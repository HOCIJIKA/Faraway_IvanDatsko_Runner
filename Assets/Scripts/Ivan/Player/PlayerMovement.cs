using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    private const float RayLength = 0.45f;
    
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _restartPosition;
    
    public Rigidbody2D PlayerRigidbody { get; private set; }
    private Animator Animator { get; set; }
    public bool IsJump { get; set; }
    public bool IsGrounded { get; private set; }
    public bool IsStarted { private get; set; }
    
    private void Awake()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        if (!IsStarted)
        {
            Animator.SetBool("grounded", false);
            Animator.SetFloat("velocityX", 1);
            return;
        }
        
        CheckGround();
        
        Animator.SetBool("grounded", IsGrounded);
        Animator.SetFloat("velocityX", 1);

#if UNITY_EDITOR
        IsJump = Input.GetButtonDown("Jump");
#endif
    }

    public void Restart()
    {
        PlayerRigidbody.velocity = Vector2.zero;
        transform.position = _restartPosition.position;
        StopAllCoroutines();
    }
    
    private void CheckGround()
    {
        Vector2 direction = Vector2.down;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, RayLength, _groundLayer);
        IsGrounded = hit.collider != null;
    }
}
