using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Collected all interactive object which need to be renewed after the player restarts
/// </summary>
public class MapController : MonoBehaviour
{
        [Tooltip("Add all interactive objects that need to be updated after the player restarts")]
    [SerializeField] private List<Buff> _interactiveObjects;

    private void Awake()
    {
        Application.targetFrameRate = 144; // set the target frame rate to make the game smooth.
        
        StaticActions.RestartPlayer += ResetAll;
    }
    
    /// <summary>
    /// Reset interactives
    /// </summary>
    private void ResetAll()
    {
        foreach (var interactiveObject in _interactiveObjects)
        {
            interactiveObject.ResetObjectAfterRestart();
        }
    }

    private void OnDestroy()
    {
        StaticActions.RestartPlayer -= ResetAll;
    }
}
