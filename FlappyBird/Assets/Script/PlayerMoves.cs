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


    void Start()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && gM.IsGameOver == false)
        {
            playerRb.AddForce(forcaPulo);
            playerRb.velocity = new Vector2(0, 0);
        }

        fire();
        gM.quantMunin.text = quantMunicao.ToString();
        gM.checarMunin = quantMunicao;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstaculo")
        {
            //playerFx.Play(somMorte);
            gM.IsGameOver = true;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RayGun")
        {
            quantMunicao += 5;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "projetilEnemy")
        {
            gM.IsGameOver = true;
            Destroy(collision.gameObject);
        }
    }
    private void fire()
    {
        if (Input.GetButtonDown("Fire1") && !gM.IsGameOver && quantMunicao > 0 && gM.IsPaused == false)
        {
            quantMunicao--;
            Instantiate(projetil, localDisparo.position, Quaternion.identity);
            anim.SetTrigger("fire");
        }
    }
}
