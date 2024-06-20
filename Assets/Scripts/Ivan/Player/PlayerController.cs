using System.Collections;
using Ivan.MoveModifiers;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]

public class PlayerController : MonoBehaviour
{
    public PlayerMovement PlayerMovement { get; private set; }
    private Coroutine _currentBuffDurationRoutine { get; set; }
    
    private IMovable _movable { get; set; }

    private bool _isStarted { get; set; }    
    private void Awake()
    {
        PlayerMovement = GetComponent<PlayerMovement>();
        _movable = new DefaultMove();

        StaticActions.RestartMap += Restart;
    }
    
    private void Start()
    { 
        StartCoroutine(DelayToRun());
    }

    private void Update()
    {
        PlayerMovement.IsStarted = _isStarted;
        
        if (!_isStarted)
        {
            return;
        }
        
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
    
    private IEnumerator ResetToDefaultAfter(float duration)
    {
        yield return new WaitForSeconds(duration);
        _movable = new DefaultMove();
    }
    
    private IEnumerator DelayToRun()
    {
        _isStarted = false;
        yield return new WaitForSeconds(1);
        _isStarted = true;
    }

    private void Restart()
    {
        _movable = new DefaultMove();
        StartCoroutine(DelayToRun());
        PlayerMovement.Restart();
    }

    private void OnDestroy()
    {
        StaticActions.RestartMap -= Restart;
    }
}
