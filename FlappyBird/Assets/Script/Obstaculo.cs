using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public float speed;

    private GameManager gM;

    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);

        DestruirObjeto();



    }

    void DestruirObjeto()
    {
        if(transform.position.x <= -10 && gM.Xcoin == false)
        {
            Destroy(gameObject);
            if (gM.IsGameOver == false)
            {
                gM.pontuacaof++;
            }
        }
        if (transform.position.x <= -10 && gM.Xcoin == true)
        {
            Destroy(gameObject);
            if (gM.IsGameOver == false)
            {
                gM.pontuacaof++;
                gM.pontuacaof++;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Municao" && gM.Xcoin == false)
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            gM.pontuacaof++;
        }


        if (collision.gameObject.tag == "Municao" && gM.Xcoin == true)
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            gM.pontuacaof++;
            gM.pontuacaof++;
        }
    }
}
