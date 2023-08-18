using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool IsGameOver;
    public GameObject obstaculo, obstaculo_i;

    private float intervalo;
    public float delay = 3;
    public float pontuacaof;
    public TextMeshProUGUI pontuacao;


    // Start is called before the first frame update
    void Start()
    {
        intervalo = Time.time + delay;
        pontuacao.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        RespawnManager();
        pontuacao.text = pontuacaof.ToString();
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
} 

