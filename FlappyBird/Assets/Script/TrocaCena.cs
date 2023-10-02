using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaCena : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("TutorialA");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
