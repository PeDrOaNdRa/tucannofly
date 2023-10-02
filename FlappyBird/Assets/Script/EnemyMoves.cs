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

    //public GameManager gM;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enemyRb = GetComponent<Rigidbody2D>();
        //gM = GameObject.Find("GameManager").GetComponent<GameManager>();

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


        EnemyShot();

    }
    public void EnemyShot()
    {
        if (intervalo <= Time.time && transform.position.x <= posicao69)
        {
            Instantiate(projetilEnemy,localDisparo.transform.position,Quaternion.identity);
            anim.SetTrigger("fire");
            intervalo = Time.time + delay;
        }
    }
}
