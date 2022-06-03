using System.Collections;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    public GameObject obstacle;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            int rXpos = Random.Range(-7, 7);
            Instantiate(obstacle, new Vector3(rXpos, 1, transform.position.z + i * 4), Quaternion.identity);
        }
    }

}
