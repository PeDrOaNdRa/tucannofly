using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public float speed;

    private GameManager gM;

    private Animator animObst; 

    // Start is called before the first frame update
    void Start()
    {
        animObst = GetComponent<Animator>();
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
        speed += gM.speedToAdd;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);

        DestruirObjeto();
    }

    void DestruirObjeto()
    {
        if (transform.position.x <= -10)
        {
            Destroy(gameObject);
            if (gM.IsGameOver == false)
            {
                gM.pontuacaof++;
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projetil" || collision.gameObject.tag == "player")
        {
            gM.pontuacaof++;
            Destroy(collision.gameObject);
            animObst.SetTrigger("expObst");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            animObst.SetTrigger("expObst");
        }
    }

    public void Destruir()
    {
        Destroy(this.gameObject);
    }
}
