using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int enemyLives = 3;
    bool[] appleMap;
    [SerializeField]private TMPro.TextMeshProUGUI livesText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        appleMap = gameObject.GetComponent<WheelScript>().appleMap;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void handleEnemyTurn(int wheelValue) {
        if (appleMap[wheelValue - 1]) {
            Debug.Log("Enemy Lives");
        } else {
            enemyLives--;
            livesText.text = "Lives: " + enemyLives;
        }
    }
}
