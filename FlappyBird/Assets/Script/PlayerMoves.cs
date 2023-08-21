using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public Vector2 forcaPulo;
    public GameManager gM;
    private Animator anim;
    
    void Start()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && gM.IsGameOver == false)
        {
            playerRb.AddForce(forcaPulo);
            playerRb.velocity = new Vector2(0, 0);
        }
        fire();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstaculo")
        {
            gM.IsGameOver = true;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "RayGun")
        {
            gM.ImWithRayGun = true;
            Destroy(collision.gameObject);
        }
    }
    private void fire()
    {
        if (Input.GetButtonDown("Fire1") && gM.IsGameOver == false && gM.ImWithRayGun == true)
        {

            anim.SetTrigger("fire");
            GameObject temp = Instantiate(gM.municao);

            temp.transform.position = gM.localDisparo.transform.position;

            temp.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gM.velocidadeDisparo, 0);
            Destroy(temp.gameObject, 2);
            
        }
    }
    
}
