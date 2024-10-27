using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public ButtonScript buttonScript;
    private WheelScript wheelScript;
    public int enemyDeaths = 0;
    bool[] appleMap;
    public GameObject[] lifeObjects = new GameObject[3];
    public GameObject audioSuccessController;
    public GameObject failAudioController;

    public GameObject panel;
    float countdownTimeSecond = 3f;
    float vigValue = 0;
    private Image panelImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wheelScript = GetComponent<WheelScript>();
        appleMap = gameObject.GetComponent<WheelScript>().appleMap;   
        panelImage = panel.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyDeaths >= 3){
            panel.SetActive(true);
            countdownTimeSecond -= Time.deltaTime;
            vigValue += Time.deltaTime;
            panelImage.color = new Color(1f,1f,1f,vigValue);
            if(countdownTimeSecond <= 0){
                SceneManager.LoadScene("SampleScene");
            }
        }
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
        buttonScript.damageValue = 1;
        updateLifeObjects();
    }
}
