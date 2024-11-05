using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class TalkingScript : MonoBehaviour
{

    public TextMeshProUGUI speakingText;

    public Animator monsterAnimator;

    float countdownTime = 3f;
    float countdownTimeTwo = 0.5f;
    bool timeStart = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        showText();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStart)
        {   
            
            StartCoroutine(fadeInText());
            countdownTime -= Time.deltaTime;
            if(countdownTime <= 0){
                speakingText.gameObject.SetActive(false);
                monsterAnimator.SetBool("isTalking", false);
                StartCoroutine(fadeOutText());
                countdownTimeTwo -= Time.deltaTime;
                if(countdownTimeTwo <= 0){
                    countdownTime = 3f;
                    countdownTimeTwo = 0.5f;
                    timeStart = false;
                    speakingText.gameObject.SetActive(false);
                }
                
            }
            
        }
    }

    public IEnumerator fadeInText(){
        speakingText.color = new Color(speakingText.color.r, speakingText.color.g, speakingText.color.b, 0);
        while (speakingText.color.a < 1.0f)
        {
            speakingText.color = new Color(speakingText.color.r, speakingText.color.g, speakingText.color.b, speakingText.color.a + (Time.deltaTime / 1));
            yield return null;
        }
    }
    public IEnumerator fadeOutText(){
        speakingText.color = new Color(speakingText.color.r, speakingText.color.g, speakingText.color.b, 1);
        while (speakingText.color.a > 0.0f)
        {
            speakingText.color = new Color(speakingText.color.r, speakingText.color.g, speakingText.color.b, speakingText.color.a - (Time.deltaTime / 1));
            yield return null;
        }
    }
    public void showText(){
        monsterAnimator.SetBool("isTalking", true);
        timeStart = true;
        speakingText.gameObject.SetActive(true);
    }

    public void changeText(string newText){
        speakingText.text = newText;
        showText();
    }
}
