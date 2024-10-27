using UnityEngine;

public class ClickController : MonoBehaviour
{
    public GameObject canvas;
    public bool isSpinning;
    public AudioSource clickSource;
    public float timer = 0.0f;
    public float tickTime = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clickSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        isSpinning = canvas.GetComponent<ButtonScript>().spinnerActivated;
        if (isSpinning) {
            if (timer <= 0) {
                clickSource.Play(0);
                timer = tickTime;
            }
            timer -= Time.deltaTime;
        }
    }
}
