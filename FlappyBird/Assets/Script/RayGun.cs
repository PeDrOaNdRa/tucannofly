using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGun : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
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
        }
    }
}
