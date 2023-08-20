using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool IsGameOver, ImWithRayGun,Xcoin;
    public GameObject obstaculo, obstaculo_i, localDisparo, municao, raygun;

    private float intervalo;
    public float delay = 3;
    public float pontuacaof;
    public TextMeshProUGUI pontuacao;
    public float velocidadeDisparo;
    public int spawnEnemy;
    //private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
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

        if (Input.GetButtonDown("Fire1") && IsGameOver == false && ImWithRayGun == true)
        {
            //anim.SetTrigger("fire");

            GameObject temp = Instantiate(municao);

            temp.transform.position = localDisparo.transform.position;

            temp.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeDisparo, 0);
            Destroy(temp.gameObject, 2);
        }
        
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
            Instantiate(raygun, new Vector3(Random.Range(10, 17), Random.Range(-3, 5), 0), Quaternion.identity);
        }
    }
} 

