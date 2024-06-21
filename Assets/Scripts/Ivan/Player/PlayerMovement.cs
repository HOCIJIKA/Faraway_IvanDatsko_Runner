using UnityEngine;

/// <summary>
/// Calculating animation and collect base fields for moving.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    private const float RayLength = 0.45f;
    
    /// <summary>
    /// Select Layer to check the ground objects
    /// </summary>
    [SerializeField] private LayerMask _groundLayer;
    
    /// <summary>
    /// Position to move the player on the start
    /// </summary>
    [SerializeField] private Transform _restartPosition;
    

    /// <summary>
    /// If Player in a jump
    /// </summary>
    public bool IsJump { get; set; }
    
    /// <summary>
    /// If Player on the ground
    /// </summary>
    public bool IsGrounded { get; private set; }
    
    /// <summary>
    /// If run is started
    /// </summary>
    public bool IsRunStarted { private get; set; }
    
    /// <summary>
    /// Rigidbody of Player
    /// </summary>
    public Rigidbody2D PlayerRigidbody { get; private set; }
    
    /// <summary>
    /// Player Animator
    /// </summary>
    private Animator Animator { get; set; }

    private void Awake()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    private void Start()
    {
        transform.position = _restartPosition.position;
    }

    private void Update()
    {
        if (!IsRunStarted)
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

    /// <summary>
    /// Restart player moving
    /// </summary>
    public void Restart()
    {
        PlayerRigidbody.velocity = Vector2.zero;
        transform.position = _restartPosition.position;
        StopAllCoroutines();
    }

    /// <summary>
    /// Check ground by RaycastHit
    /// </summary>
    private void CheckGround()
    {
        Vector2 direction = Vector2.down;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, RayLength, _groundLayer);
        IsGrounded = hit.collider != null;
    }
}