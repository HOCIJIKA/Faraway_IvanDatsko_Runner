using System;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Player _playerTransform;

    [SerializeField] private List<GameObject> _scenePrefabs;

    [SerializeField] private GameObject _crystal; //Slow
    [SerializeField] private GameObject _asteroid; //fast
    [SerializeField] private GameObject _mushroom; //Fly
    
    
    private void Awake()
    {
    }
}
