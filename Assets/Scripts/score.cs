using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;

    // Update is called once per frame
    void Update()
    {
        // Get the players position
        float position = player.position.z;
        // Using the position update the score
        scoreText.text = position.ToString("0");
    }
}
