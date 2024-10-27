using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int enemyDeaths = 0;
    bool[] appleMap;
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
        for (int i = 0; i < enemyDeaths; i++) {
            lifeObjects[i].SetActive(true);
        }
    }

    public void handleEnemyTurn(int wheelValue) {
        if (appleMap[wheelValue - 1]) {
            Debug.Log("Enemy Lives");
        } else {
            Debug.Log("Enemy loses life");
            enemyDeaths++;
        }
        updateLifeObjects();
    }
}
