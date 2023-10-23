using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public float speed;

    private GameManager gM;

    private Animator animObst;

    public AudioSource obstcSource;
    public AudioClip somExplosion;

    private Collider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GetComponent<Collider2D>();
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
        if (transform.position.x <= -10 && gM.IsGameOver == false)
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
        if (collision.gameObject.tag == "Projetil" || collision.gameObject.tag == "player" && gM.IsGameOver == false)
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            gM.gmAudio.PlayOneShot(gM.somMorte);
            Destroy(collision.gameObject);
            animObst.SetTrigger("expObst");
            if(gM.IsGameOver == false)
            {
                gM.pontuacaof++;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player" && gM.IsGameOver == false)
        {
            animObst.SetTrigger("expObst");
        }
    }

    public void Destruir()
    {
        Destroy(this.gameObject);
    }
}
