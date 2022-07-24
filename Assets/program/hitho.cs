using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitho : MonoBehaviour
{

    public float ins;
    int point = 1000;

    GameObject killer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,ins,0);

        if(transform.position.y > 150)
        {
            Destroy(this.gameObject);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "enemy")
            Destroy(this.gameObject);
    }
    
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
