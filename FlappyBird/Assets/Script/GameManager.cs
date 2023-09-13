using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool IsGameOver, ImWithRayGun;
    public GameObject obstaculo, obstaculo_i, municao;

    public float delay = 3;
    public float delayMunicao = 20;
    public float pontuacaof,intervalo,intervaloMunicao,velocidadeDisparo;
    public TextMeshProUGUI pontuacao,quantMunin;
    public int spawnEnemy;
    public float speedToAdd;
    public float checarPontuacao = 10;
    public float checarMunin;

    public GameObject botaoPausar;
    public GameObject telaPause;
    public GameObject telaGameOver;

    // Start is called before the first frame update
    void Start()
    {
        pontuacaof = 0;
        intervalo = Time.time + delay;
        intervaloMunicao = Time.time + delayMunicao;
        spawnEnemy = Random.Range(-3, 7);
        pontuacao.text = "0";
        quantMunin.text = "0";
        
    }

    // Update is called once per frame
    void Update()
    {
        Dificuldade();

        RespawnRayGunManager();

        RespawnManager();

        pontuacao.text = pontuacaof.ToString();

        GameOver();
    }

    public void RespawnManager()
    {
        if(intervalo <= Time.time)
        {

            Instantiate(obstaculo, new Vector3(Random.Range(11, 17), Random.Range(-3, 5), 0), Quaternion.identity);
            Instantiate(obstaculo, new Vector3(Random.Range(15, 19), Random.Range(-4, 4), 0), Quaternion.identity);
            intervalo = Time.time + delay;

            if (intervaloMunicao <= Time.time && pontuacaof >= 100)
            {
                Instantiate(obstaculo, new Vector3(Random.Range(16, 18), Random.Range(4.2f, -4.2f), 0), Quaternion.identity);
            }
        }
    }
    public void RespawnRayGunManager()
    {
        if (intervaloMunicao <= Time.time && checarMunin != 10)
        {
            Instantiate(municao, new Vector3(Random.Range(14, 17), Random.Range(4.2f, -4.2f), 0), Quaternion.identity);
            intervaloMunicao = Time.time + delayMunicao;
        }
    }
    void Dificuldade()
    {
        if (checarPontuacao == pontuacaof)
        {
            speedToAdd += 0.5f;
            checarPontuacao = checarPontuacao + 10;
        }
    }
    public void GameOver()
    {
        if(IsGameOver == true)
        {
            telaGameOver.SetActive(true);
            botaoPausar.SetActive(false);
        }
    }

    public void Pausar()
    {
        if (IsGameOver == false)
        {
            Time.timeScale = 0;
            botaoPausar.SetActive(false);
            telaPause.SetActive(true);
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        botaoPausar.SetActive(true);
        telaPause.SetActive(false);
    }
} 

