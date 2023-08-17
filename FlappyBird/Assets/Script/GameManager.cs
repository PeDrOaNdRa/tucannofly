using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool IsGameOver;
    public GameObject obstaculo;

    private float intervalo;
    public float delay = 3;
    public float pontuacaof;
    public TextMeshProUGUI pontuacao;


    // Start is called before the first frame update
    void Start()
    {
        intervalo = Time.time + delay;

    }

    // Update is called once per frame
    void Update()
    {
        RespawnManager();
    }

    public void RespawnManager()
    {
        if(intervalo <= Time.time && IsGameOver == false)
        {
            Instantiate(obstaculo, new Vector3(Random.Range(10, 17), Random.Range(-4, 4), 0), Quaternion.identity);
            intervalo = Time.time + delay;
        }
    }
} 

