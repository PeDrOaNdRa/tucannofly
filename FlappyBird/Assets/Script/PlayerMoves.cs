using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public Vector2 forcaPulo;
    public GameManager gM;
    private Animator anim;

    private float quantMunicao;
    public Transform localDisparo;
    public GameObject projetil, sensorTeto;
    public ParticleSystem playerFx;

    private bool IsTouchingTop;

    public AudioSource playerSource;
    public AudioClip somPulo,somMorte, somTiro,somColeta,somGameOver;


    void Start()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && gM.IsGameOver == false && IsTouchingTop == false)
        {
            playerSource.PlayOneShot(somPulo);
            playerRb.AddForce(forcaPulo);
            playerRb.velocity = new Vector2(0, 0);
        }

        Fire();
        gM.quantMunin.text = quantMunicao.ToString();
        gM.checarMunin = quantMunicao;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstaculo")
        {
            playerSource.PlayOneShot(somMorte);
            playerFx.Play();
            playerSource.PlayOneShot(somGameOver);
            gM.IsGameOver = true;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RayGun")
        {
            playerSource.PlayOneShot(somColeta);
            quantMunicao += 5;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "projetilEnemy")
        {
            playerSource.PlayOneShot(somMorte);
            gM.IsGameOver = true;
            playerSource.PlayOneShot(somGameOver);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "teto")
        {
            IsTouchingTop = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {        
        if (collision.gameObject.tag == "teto")
        {
            IsTouchingTop = false;
        }
    }
    private void Fire()
    {
        if (Input.GetButtonDown("Fire1") && !gM.IsGameOver && quantMunicao > 0 && gM.IsPaused == false)
        {
            playerSource.PlayOneShot(somTiro);
            quantMunicao--;
            Instantiate(projetil, localDisparo.position, Quaternion.identity);
            anim.SetTrigger("fire");
        }
    }
}
