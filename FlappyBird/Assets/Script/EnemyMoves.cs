using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoves : MonoBehaviour
{
    private Rigidbody2D enemyRb;
    public float speed, speedY,posicao69,altura,alturaMax;
    public Vector2 posTop,posBot,posToGo;


    // Start is called before the first frame update
    void Start()
    {

        enemyRb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= posicao69)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }

       if(transform.position.x <= posicao69)
        {
            transform.position = Vector2.MoveTowards(transform.position, posToGo, speedY);
        }

        if(transform.position.y >= posTop.y)
        {
            posToGo = posBot;
        }
        else if (transform.position.y <= posBot.y)
        {
            posToGo = posTop;
        }
        
    }
}
