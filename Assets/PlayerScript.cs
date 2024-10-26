using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    bool[] appleMap;
    [SerializeField]private TMPro.TextMeshProUGUI livesText;
    public int playerLives = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     appleMap = gameObject.GetComponent<WheelScript>().appleMap;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void handlePlayerTurn(int wheelValue) {
        if (appleMap[wheelValue - 1]) {
            Debug.Log("Player lives");
        } else {
            playerLives--;
            livesText.text = "Lives: " + playerLives;
        }
    }
}
