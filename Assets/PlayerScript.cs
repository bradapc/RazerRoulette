using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    bool[] appleMap;
    public int playerDeaths = 0;
    public GameObject[] lifeObjects = new GameObject[3];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     appleMap = gameObject.GetComponent<WheelScript>().appleMap;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void updateLifeObjects() {
        for (int i = 0; i < playerDeaths; i++) {
            lifeObjects[i].SetActive(true);
        }
    }


    public void handlePlayerTurn(int wheelValue, int damage) {

        if (appleMap[wheelValue - 1]) {
            Debug.Log("Player lives");
        } else {
            Debug.Log("Player loses life");
            playerDeaths += damage;

        }
        updateLifeObjects();
    }
}
