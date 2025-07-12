using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerSpawner : MonoBehaviour
{

    public GameObject playerPreFab;
    GameObject playerInstance;
    public int numLives = 4;
    float respawnTimer;
    public GUIStyle labelStyle;
    public TextMeshProUGUI livesText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        SpawnPlayer();

    }

    void SpawnPlayer()
    {
        numLives--;

        respawnTimer = 1;

        playerInstance = (GameObject)Instantiate(playerPreFab, transform.position, Quaternion.identity);


    }

    // Update is called once per frame
    void Update()
    {

        if (playerInstance == null && numLives > 0)
        {

            respawnTimer -= Time.deltaTime;

            if (respawnTimer <= 0)
            {
                SpawnPlayer();
            }
        }

        if (livesText != null)

        {

            if (numLives > 0 || playerInstance != null)

            {

                livesText.text = "Lives: " + numLives;

            }
        }
    
            if (numLives <= 0 && playerInstance == null)
            {

                SceneManager.LoadScene("GameOver");

            }
        }
    
}
