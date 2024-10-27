using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    bool[] appleMap;
<<<<<<< Updated upstream
    public int playerDeaths = 0;
    public GameObject[] lifeObjects = new GameObject[3];
=======
    [SerializeField]private TMPro.TextMeshProUGUI livesText;
    public int playerLives = 3;
    public GameObject canvasObject;

    

>>>>>>> Stashed changes
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     appleMap = gameObject.GetComponent<WheelScript>().appleMap;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

<<<<<<< Updated upstream
    public void updateLifeObjects() {
        for (int i = 0; i < playerDeaths; i++) {
            lifeObjects[i].SetActive(true);
        }
    }

    public void handlePlayerTurn(int wheelValue) {
=======
    public void handlePlayerTurn(int wheelValue, int damage) {
>>>>>>> Stashed changes
        if (appleMap[wheelValue - 1]) {
            Debug.Log("Player lives");
        } else {
            Debug.Log("Player loses life");
<<<<<<< Updated upstream
            playerDeaths++;
=======
            playerLives -= damage;
            livesText.text = "Lives: " + playerLives;
>>>>>>> Stashed changes
        }
        updateLifeObjects();
    }
}
