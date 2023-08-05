using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    private float abobrinha;
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
        if(gM.IsGameOver == false)
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        DestruirObjeto();
    }

    void DestruirObjeto()
    {
        if(transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }
}
