using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject spawnObject;

    public static SpawnerController Instance;

    void Awake()
    {
        Instance = this;
        InvokeRepeating("SpawnObject", 2f, 2f);
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnObject();
    }

    public void SpawnObject()
    {
        Instantiate(spawnObject);
    }
}
