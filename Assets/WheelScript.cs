using UnityEngine;

public class WheelScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void handleTurnEnd(int wheelValue, bool playerTurn) {
        if (playerTurn) {
            gameObject.GetComponent<PlayerScript>().handlePlayerTurn(wheelValue);
        } else {
            //handleEnemyTurn(wheelValue);
        }
    }
}
