using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaCena : MonoBehaviour
{
    public GameObject primFala, segFala, terFala, quarFala, quiFala;

    public void VoltarInicio()
    {
        SceneManager.LoadScene("StartScreen");
        Time.timeScale = 1;
    }
    public void PlayT()
    {
        SceneManager.LoadScene("InGame");
        Time.timeScale = 1;
    }
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
    public void IraParaPrimeiraFala()
    {
        primFala.SetActive(true);
        segFala.SetActive(false);
        terFala.SetActive(false);
        quarFala.SetActive(false);
        quiFala.SetActive(false);
    }
    public void IraParaSegundaFala()
    {
        primFala.SetActive(false);
        segFala.SetActive(true);
        terFala.SetActive(false);
        quarFala.SetActive(false);
        quiFala.SetActive(false);
    }
    public void IraParaTerceiraFala()
    {
        primFala.SetActive(false);
        segFala.SetActive(false);
        terFala.SetActive(true);
        quarFala.SetActive(false);
        quiFala.SetActive(false);
    }
    public void IraParaQuartaFala()
    {
        primFala.SetActive(false);
        segFala.SetActive(false);
        terFala.SetActive(false);
        quarFala.SetActive(true);
        quiFala.SetActive(false);
    }
    public void IraParaQuintaFala()
    {
        primFala.SetActive(false);
        segFala.SetActive(false);
        terFala.SetActive(false);
        quarFala.SetActive(false);
        quiFala.SetActive(true);
    }
}
