using Ivan.MoveModifiers;
using UnityEngine;

/// <summary>
/// Monobeh for interactive object.
/// Collected all Buffs (Move Parameters tittles)
/// </summary>
public class Buff : MonoBehaviour
{
    private IMovable _movable;
    
    /// <summary>
    /// enum of tittles
    /// </summary>
    private enum Buffs
    {
        None,
        Fast,
        Slow,
        Fly
    }

    [Tooltip("Select buff")]
    [SerializeField] private Buffs _buff = Buffs.None;
    
    /// <summary>
    /// default buff duration
    /// </summary>
    [SerializeField] private float _defaultBuffDuration = 10;
    
    
    private void Awake()
    {
        SelectMoveParameters();
    }

    /// <summary>
    /// Reset buff object
    /// </summary>
    public void ResetObjectAfterRestart()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Select move parameters
    /// </summary>
    private void SelectMoveParameters()
    {
        switch (_buff)
        {
            case Buffs.Fast:
                _movable = new FastMove();
                break;
            
            case Buffs.Slow:
                _movable = new SlowMove();
                break;
            
            case Buffs.Fly:
                _movable = new Fly();
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnCollisionWithPLayer(other.GetComponent<PlayerController>());
        }
    }

    /// <summary>
    /// Player got the buff
    /// </summary>
    /// <param name="playerController">PlayerController</param>
    private void OnCollisionWithPLayer(PlayerController playerController)
    {
        playerController.SetMoveModifier(_movable, _defaultBuffDuration); //Set new move parameters for player
        gameObject.SetActive(false);
    }
    
}
