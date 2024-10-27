using UnityEngine;
using TMPro;

public class WheelScript : MonoBehaviour
{
    //HIT TRUE = LIVE, FALSE = LOSE A LIFE
    public bool[] appleMap = {false, true, false, true, false, true, false, true, false, true, false, true};

    public TextMeshProUGUI safeValueText;
    public TextMeshProUGUI unsafeValueText;

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

    public void updateOdds(int wheelValue){
        int safe = 0;
        int unSafe = 0 ;

        appleMap[wheelValue - 1] = !appleMap[wheelValue - 1];
        for (int i = 0; i < appleMap.Length; i++)
        {
            if(appleMap[i]){
                safe++;
            }
            else{
                unSafe++;
            }
        }

        safeValueText.text = safe.ToString();
        unsafeValueText.text = unSafe.ToString();

    }
}
