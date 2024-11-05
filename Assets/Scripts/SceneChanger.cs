using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void sceneChange()
    {
        Debug.Log("Button Click");
        SceneManager.LoadScene("SampleScene");
    }
}
