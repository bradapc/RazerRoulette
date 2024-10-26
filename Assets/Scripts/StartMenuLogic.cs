using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuLogic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sceneChange()
    {
        Debug.Log("Button Click");
        SceneManager.LoadScene("SampleScene");
    }

    public void quitGame()
    {
        Debug.Log("Quit Button Click");
        Application.Quit();
    }
}
