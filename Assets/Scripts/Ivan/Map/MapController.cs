using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _disabledObjects;

    private void Awake()
    {
        Application.targetFrameRate = 144;
        
        StaticActions.RestartMap += EnableAll;
    }

    private void EnableAll()
    {
        foreach (var disabledObject in _disabledObjects)
        {
            disabledObject.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        StaticActions.RestartMap -= EnableAll;
    }
}
