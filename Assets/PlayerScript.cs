using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]private TMPro.TextMeshProUGUI livesText;
    bool[] appleMap = {false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true};
    public int playerLives = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void handlePlayerTurn(int wheelValue) {
        if (appleMap[wheelValue - 1]) {

        } else {
            playerLives--;
            livesText.text = "Lives: " + playerLives;
        }
    }
}
