using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public int zPos = 50;
    public bool creatingSection = false;
    public GameObject ground;
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        if (creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    // Generate a new ground which will also call obstacle generation
    IEnumerator GenerateSection()
    {
        // Create ground
        Instantiate(ground, new Vector3(0, 0, zPos), Quaternion.identity);
        // Shift the generation to be 50 from the end
        zPos += 50;
        yield return new WaitUntil(() => player.position.z > zPos - 100);
        creatingSection = false;
    }
}
