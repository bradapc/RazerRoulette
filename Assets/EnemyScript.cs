using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private WheelScript wheelScript;
    public int enemyDeaths = 0;
    bool[] appleMap;
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
        
    }

    public void updateLifeObjects() {
        for (int i = 0; i < enemyDeaths; i++) {
            lifeObjects[i].SetActive(true);
        }
    }


    public void handleEnemyTurn(int wheelValue ,int damage) {

        if (appleMap[wheelValue - 1]) {
            Debug.Log("Enemy Lives");
            // appleMap[wheelValue - 1] = !appleMap[wheelValue - 1];
            audioSuccessController.GetComponent<AudioSource>().Play(0);
            wheelScript.updateOdds(wheelValue);
        } else {
            Debug.Log("Enemy loses life");

            enemyDeaths += damage;
            // appleMap[wheelValue - 1] = !appleMap[wheelValue - 1];
            failAudioController.GetComponent<AudioSource>().Play(0);
            wheelScript.updateOdds(wheelValue);
        }
        
        updateLifeObjects();
    }
}
