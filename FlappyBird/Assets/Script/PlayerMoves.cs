using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public Vector2 forcaPulo;
    public GameManager gM;
    void Start()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>;
        playerRb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && gM.isGameOver == false)
        {
            playerRb.AddForce(forcaPulo);
            playerRb.velocity = new Vector2(0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstaculo")
        {
            gM.isGameOver = true;
        }
    }
}
