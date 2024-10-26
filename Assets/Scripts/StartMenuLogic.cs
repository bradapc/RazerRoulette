using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuLogic : MonoBehaviour
{
    public GameObject aboutPanel;
    public GameObject optionPanel;

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

    public void aboutMenuVisibilityToggle()
    {
        aboutPanel = transform.Find("AboutPanel").gameObject;
        if(aboutPanel != null)
        {
            Debug.Log("Panel Found!");
            aboutPanel.SetActive(!aboutPanel.activeSelf);
        }
        else
        {
            Debug.Log("Panel not found!");
        }
    }

    public void aboutOptionVisibilityToggle()
    {
        optionPanel = transform.Find("OptionsPanel").gameObject;
        if (optionPanel != null)
        {
            Debug.Log("Panel Found!");
            optionPanel.SetActive(!optionPanel.activeSelf);
        }
        else
        {
            Debug.Log("Panel not found!");
        }
    }


}
