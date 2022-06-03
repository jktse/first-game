using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    private Transform playerTransform;

    public GameObject[] groundPrefab;
    public float zPos = 10;
    public float groundLength = 25;
    public int amountOfGround = 7;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        // I want to create 7 platforms
        for (int i = 0; i < amountOfGround; i++)
        {
            SpawnGround();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(playerTransform.position.z > (zPos - amountOfGround * groundLength))
        {
            SpawnGround();
        }
    }

    private void SpawnGround(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(groundPrefab[0]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * zPos;
        zPos += groundLength;
    }
}
