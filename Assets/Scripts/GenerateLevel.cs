using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    private Transform playerTransform;
    private List<GameObject> activeGround;

    public GameObject[] groundPrefab;
    public float zPos = 10;
    public float groundLength = 25;
    public float safeZone = 28;
    public int amountOfGround = 7;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        activeGround = new List<GameObject>();
        // I want to create 7 platforms
        for (int i = 0; i < amountOfGround; i++)
        {
            SpawnGround();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(playerTransform.position.z - safeZone > (zPos - amountOfGround * groundLength))
        {
            SpawnGround();
            DeleteGround();
        }
    }

    private void DeleteGround()
    {
        Destroy(activeGround[0]);
        activeGround.RemoveAt(0);
    }

    private void SpawnGround(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(groundPrefab[0]);
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * zPos;
        zPos += groundLength;
        activeGround.Add(go);
    }
}
