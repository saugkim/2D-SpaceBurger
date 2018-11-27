using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuConstrol : MonoBehaviour
{

    public GameObject panel;

    public void StartGame()
    {

        SceneManager.LoadScene(1);
    }

    public void ViewOption()
    {
        panel.SetActive(true);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }
}
