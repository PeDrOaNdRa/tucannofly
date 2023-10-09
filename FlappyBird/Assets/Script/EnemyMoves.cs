using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoves : MonoBehaviour
{
    private Rigidbody2D enemyRb;
    public float speed, speedY, posicao69;
    public Vector2 posTop, posBot, posToGo;

    public GameObject localDisparo;
    public GameObject projetilEnemy; 

    public float delay = 2.5f;
    public float intervalo;

    private Animator anim;

    public GameManager gM;

    public AudioSource enemySource;
    public AudioClip somMorte,somTiro;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enemyRb = GetComponent<Rigidbody2D>();
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= posicao69)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }


        if (transform.position.x <= posicao69)
        {
            transform.position = Vector2.MoveTowards(transform.position, posToGo, speedY);
        }

        if (transform.position.y >= posTop.y)
        {
            posToGo = posBot;
        }
        else if (transform.position.y <= posBot.y)
        {
            posToGo = posTop;
        }

        //EnemyShot();
        AcionarAnimTiro();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projetil")
        {
            enemySource.PlayOneShot(somMorte);
            gM.pontuacaof++;
            Destroy(collision.gameObject);
            anim.SetTrigger("Explodes");
        }
    }

    public void AcionarAnimTiro()
    {
        if (intervalo <= Time.time && transform.position.x <= posicao69)
        {
            anim.SetTrigger("fire");
            enemySource.PlayOneShot(somTiro);
            intervalo = Time.time + delay;
        }
    }

    public void FogueteAtira()
    {
        if (transform.position.x <= posicao69)
        {
            Instantiate(projetilEnemy,localDisparo.transform.position,Quaternion.identity);
        }
    }

    public void Destuir()
    {
        gM.EnemyOnDisplay = false;
        Destroy(this.gameObject);
    }
}
