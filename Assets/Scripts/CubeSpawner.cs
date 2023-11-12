using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> _cubePrefabs;
    public static event Action OnSpawn;

    private void OnEnable()
    {
        CubeScript.OnDestroyed += SpawnCube;
    }

    private void OnDisable()
    {
        CubeScript.OnDestroyed -= SpawnCube;
    }

    void Start()
    {
        SpawnCube();
    }

    private void SpawnCube()
    {
        int randomPrefabIndex = UnityEngine.Random.Range(0, _cubePrefabs.Count);
        Instantiate(_cubePrefabs[randomPrefabIndex], Vector3.zero, quaternion.identity);
        OnSpawn?.Invoke();
    }
}
