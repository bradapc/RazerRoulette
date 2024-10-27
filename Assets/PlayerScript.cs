using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public ButtonScript buttonScript;
    private WheelScript wheelScript;
    bool[] appleMap;
    public int playerDeaths = 0;
    public GameObject[] lifeObjects = new GameObject[3];
    public GameObject audioSuccessController;
    public GameObject failAudioController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wheelScript = GetComponent<WheelScript>();
        appleMap = gameObject.GetComponent<WheelScript>().appleMap;   
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDeaths >= 3)
        {
            SceneManager.LoadScene("MainMenu");
        }
        
    }

    public void updateLifeHeal() {
        if(playerDeaths>=0){
            lifeObjects[playerDeaths].SetActive(false);
            playerDeaths--;
        }
    }

    public void updateLifeObjects() {
        for (int i = 0; i < playerDeaths; i++) {
            lifeObjects[i].SetActive(true);
        }
    }


    public void handlePlayerTurn(int wheelValue, int damage) {

        if (appleMap[wheelValue - 1]) {
            Debug.Log("Player lives");
            // appleMap[wheelValue - 1] = !appleMap[wheelValue - 1];
            wheelScript.updateOdds(wheelValue);
            audioSuccessController.GetComponent<AudioSource>().Play(0);
        } else {
            Debug.Log("Player loses life");
            playerDeaths += damage;
            // appleMap[wheelValue - 1] = !appleMap[wheelValue - 1];
            failAudioController.GetComponent<AudioSource>().Play();
            wheelScript.updateOdds(wheelValue);

        }
        buttonScript.damageValue = 1;
        updateLifeObjects();
    }
}
