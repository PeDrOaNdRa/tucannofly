using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed;
    public float limiteX;
    public float inicioX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= limiteX)
        {
            transform.position = new Vector2(inicioX, transform.position.y);
        }

        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
    }
}
