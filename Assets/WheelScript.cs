using UnityEngine;

public class WheelScript : MonoBehaviour
{
    public bool[] appleMap = {false, true, false, true, false, true, false, true, false, true, false, true};
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void handleTurnEnd(int wheelValue, string turn) {
        if (turn == "player") {
            gameObject.GetComponent<PlayerScript>().handlePlayerTurn(wheelValue);
        } else {
            gameObject.GetComponent<EnemyScript>().handleEnemyTurn(wheelValue);
        }
    }
}
