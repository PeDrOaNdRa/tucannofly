using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool IsGameOver, ImWithRayGun, IsPaused;
    public GameObject obstaculo, obstaculo_i, municao, enemy;

    public float delay = 3;
    public float delayMunicao = 20;
    public float pontuacaof,intervalo,intervaloMunicao,velocidadeDisparo;
    public TextMeshProUGUI pontuacao,quantMunin;
    public int spawnEnemy, maxObst = 1;
    public float speedToAdd;
    public float baseSpeed;
    public float checarPontuacao = 10, incrementoChecador = 10;
    public float checarMunin;

    public GameObject botaoPausar;
    public GameObject telaPause;
    public GameObject telaGameOver;
    public GameObject gameCanva;

    public float contadorInimigo;
    public float pontoInimigoToAdd = 1;

    // Start is called before the first frame update
    void Start()
    {
        pontuacaof = 0;
        intervalo = Time.time + delay;
        intervaloMunicao = Time.time + delayMunicao;
        spawnEnemy = Random.Range(-3, 7);
        pontuacao.text = "0";
        quantMunin.text = "0";

        contadorInimigo = pontoInimigoToAdd;

    }

    // Update is called once per frame
    void Update()
    {

        Dificuldade();

        RespawnRayGunManager();

        RespawnManager();

        pontuacao.text = pontuacaof.ToString();

        SpawnEnemy();

        GameOver();
    }

    public void RespawnManager()
    {
        if(intervalo <= Time.time)
        {
            newrespawn();
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
    public void SpawnEnemy()
    {
        if (pontuacaof >= contadorInimigo)
        {
            Instantiate(enemy, new Vector3(13.59f,transform.position.y , transform.position.z), Quaternion.identity);
            contadorInimigo += pontoInimigoToAdd;
        }
    }
    void Dificuldade()
    {
        if (checarPontuacao == pontuacaof)
        {
            speedToAdd += baseSpeed;
            checarPontuacao = checarPontuacao + incrementoChecador;
            maxObst = maxObst += 1;
        }
    }   

    public void newrespawn()
    {
        for(int i = 1; i <= maxObst; i++)
        {
            Instantiate(obstaculo, new Vector3(Random.Range(11, 17), Random.Range(-3, 5), 0), Quaternion.identity);
        }
    }
    public void GameOver()
    {
        if (IsGameOver == true)
        {
            telaGameOver.SetActive(true);
            botaoPausar.SetActive(false);
            gameCanva.SetActive(false);
        }
    }

    public void Pausar()
    {
        IsPaused = true;
        if (IsGameOver == false)
        {
            Time.timeScale = 0;
            botaoPausar.SetActive(false);
            telaPause.SetActive(true);
            gameCanva.SetActive(false);
        }
    }

    public void Resume()
    {
        IsPaused = false;
        Time.timeScale = 1;
        botaoPausar.SetActive(true);
        telaPause.SetActive(false);
        gameCanva.SetActive(true);
    }

    public void Quitar()
    {
        Application.Quit();
    }
} 

