using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    public ButtonScript buttonScript;
    private WheelScript wheelScript;
    public Volume volume;
    private Vignette vignette;
    public GameObject panel;
    private Image panelImage;

    public Animator monsterAnimator;

    bool[] appleMap;
    public int playerDeaths = 0;
    public GameObject[] lifeObjects = new GameObject[3];
    public GameObject audioSuccessController;
    public GameObject failAudioController;

    public float countdownTime = 1f;
    float countdownTimeSecond = 3f;

    float countdownTimeThree = 1.3f;
    bool timeStart = false;
    float vigValue = 0;
    Color panelColor = new Color(1f, 1f, 0f, 0.0f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wheelScript = GetComponent<WheelScript>();
        appleMap = gameObject.GetComponent<WheelScript>().appleMap;   
        panelImage = panel.GetComponent<Image>();
        if (volume.profile.TryGet(out vignette))
        {
            
        }
        else
        {
            Debug.LogError("No Vignette effect found in the Volume profile. Make sure a Vignette effect is added.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDeaths >= 3)
        {
            monsterAnimator.Play("GameOverAnimation");
            countdownTimeThree -= Time.deltaTime;
            if (countdownTimeThree <= 0)
            {
                panel.SetActive(true);
                countdownTimeSecond -= Time.deltaTime;
                vigValue += Time.deltaTime;
                panelImage.color = new Color(1f,1f,1f,vigValue);
                if(countdownTimeSecond <= 0){
                    SceneManager.LoadScene("MainMenu");
                }
            }

        }
        else if (timeStart)
        {
            countdownTime -= Time.deltaTime;
            vigValue += Time.deltaTime;
            vignetteChanger((1.4f - vigValue), Color.red);
            countdownTime = Mathf.Clamp(countdownTime, 0, 1);
            if(countdownTime <= 0){
                vignetteChanger(0.3f, Color.black);
                timeStart = false;
                vigValue = 0;
            }
        }
        
    }

    public void updateLifeHeal() {
        if(playerDeaths>0){
            lifeObjects[playerDeaths-1].SetActive(false);
            playerDeaths--;
        }
    }

    public void updateLifeObjects() {
        for (int i = 0; i < playerDeaths; i++) {
            lifeObjects[i].SetActive(true);
            vignetteChanger((i+1)*0.4f, Color.red);
            timeStart = true;
        }
    }

    public void vignetteChanger(float intensity, Color color){
        vignette.intensity.value = Mathf.Clamp01(intensity);
        vignette.color.value = color;
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
