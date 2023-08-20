using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool IsGameOver, ImWithRayGun;
    public GameObject obstaculo, obstaculo_i, localDisparo, municao, raygun;

    public float delay = 3;
    public float pontuacaof,intervalo,velocidadeDisparo;
    public TextMeshProUGUI pontuacao;
    public int spawnEnemy;

    // Start is called before the first frame update
    void Start()
    {
        pontuacaof = 0;
        intervalo = Time.time + delay;
        spawnEnemy = Random.Range(-3, 6);
        pontuacao.text = "0";
        RespawnRayGunManager();
    }

    // Update is called once per frame
    void Update()
    {
        RespawnManager();

        pontuacao.text = pontuacaof.ToString();

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Municao")
        {
            Destroy(municao);
        }
        
    }

    public void RespawnManager()
    {
        if(intervalo <= Time.time)
        {
            Instantiate(obstaculo, new Vector3(Random.Range(10, 17), Random.Range(-3, 5), 0), Quaternion.identity);
            Instantiate(obstaculo, new Vector3(Random.Range(12, 18), Random.Range(-4, 4), 0), Quaternion.identity);
            intervalo = Time.time + delay;
        }
    }
    public void RespawnRayGunManager()
    {
        if (spawnEnemy >= 0 )
        {
            Instantiate(raygun, new Vector3(Random.Range(14, 17), Random.Range(-4, 6), 0), Quaternion.identity);
        }
    }
} 

