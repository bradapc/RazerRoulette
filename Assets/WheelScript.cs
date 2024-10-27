using UnityEngine;

public class WheelScript : MonoBehaviour
{
    //HIT TRUE = LIVE, FALSE = LOSE A LIFE
    public bool[] appleMap = {false, true, false, true, false, true, false, true, false, true, false, true};
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void handleTurnEnd(int wheelValue, string turn, int damageValue) {
        if (turn == "player") {
            gameObject.GetComponent<PlayerScript>().handlePlayerTurn(wheelValue, damageValue);
        } else {
            gameObject.GetComponent<EnemyScript>().handleEnemyTurn(wheelValue, damageValue);
        }
    }
}
