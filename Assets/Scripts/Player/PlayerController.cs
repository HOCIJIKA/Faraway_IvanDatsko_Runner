using System.Collections;
using Ivan.MoveModifiers;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    public PlayerMovement PlayerMovement { get; private set; }
    
    /// <summary>
    /// Coroutine for cancel modificator
    /// </summary>
    private Coroutine _currentBuffDurationRoutine { get; set; }
    
    /// <summary>
    /// move modificat
    /// </summary>
    private IMovable _movable { get; set; }
    
    /// <summary>
    /// If run is started
    /// </summary>
    private bool _isRunStarted { get; set; }
    
    private void Awake()
    {
        PlayerMovement = GetComponent<PlayerMovement>();
        _movable = new DefaultMove(); // select default move parameters

        StaticActions.RestartPlayer += Restart;
    }
    
    private void Start()
    { 
        StartCoroutine(DelayToRun());
    }

    private void Update()
    {
        PlayerMovement.IsRunStarted = _isRunStarted;
        
        if (!_isRunStarted)
        {
            return;
        }
        
        _movable.Move(this);// Call current move modificator
    }
    
    /// <summary>
    /// Set new movable parameters 
    /// </summary>
    /// <param name="movableType">IMovable released class</param>
    /// <param name="duration"> duration</param>
    public void SetMoveModifier(IMovable movableType, float duration)
    {
        if (_currentBuffDurationRoutine != default)
        {
            StopCoroutine(_currentBuffDurationRoutine);
        }
        
        _movable = movableType;
        _currentBuffDurationRoutine = StartCoroutine(ResetToDefaultAfter(duration));
    }
    
    /// <summary>
    /// Set default move parameters after duration
    /// </summary>
    /// <param name="duration">duration</param>
    /// <returns></returns>
    private IEnumerator ResetToDefaultAfter(float duration)
    {
        yield return new WaitForSeconds(duration);
        _movable = new DefaultMove();
    }
    
    /// <summary>
    /// Delay to smooth player start.
    /// </summary>
    /// <returns></returns>
    private IEnumerator DelayToRun()
    {
        _isRunStarted = false;
        yield return new WaitForSeconds(1);
        _isRunStarted = true;
    }

    /// <summary>
    /// Restart player
    /// </summary>
    private void Restart()
    {
        _movable = new DefaultMove();
        StartCoroutine(DelayToRun());
        PlayerMovement.Restart();
    }

    private void OnDestroy()
    {
        StaticActions.RestartPlayer -= Restart;
    }
}
