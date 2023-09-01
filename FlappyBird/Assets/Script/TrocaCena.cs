using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaCena : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("InGame");
    }

    public void quit()
    {
        Application.Quit();
    }
}
