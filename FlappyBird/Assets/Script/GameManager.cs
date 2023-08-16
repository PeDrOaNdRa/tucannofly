using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool IsGameOver;
    public GameObject obstaculo;

    private float intervalo;
    public float delay = 3;


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
            Instantiate(obstaculo, new Vector3(10, Random.Range(-3, 4),0), Quaternion.identity);
            intervalo = Time.time + delay;
        }
    }
} 

