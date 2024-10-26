using UnityEngine;
using UnityEngine.UI;

public class SpinnerScript : MonoBehaviour
{
    public Sprite imagePlayer;
    public Sprite imageEnemy;
    public GameObject canvas;
    public GameObject spinner;
    public SpriteRenderer spinnerRenderer;
    string turn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spinnerRenderer = spinner.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        turn = canvas.GetComponent<ButtonScript>().turn;
        if (turn == "player") {
            spinnerRenderer.sprite = imagePlayer;
        } else if (turn == "enemy") {
            spinnerRenderer.sprite = imageEnemy;
        }
    }
}
