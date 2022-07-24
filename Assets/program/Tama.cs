using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tama : MonoBehaviour
{
   float move = 0.5f;
   bool run;
   GameObject targetObject;
    // Start is called before the first frame update
    void Start()
    {
        targetObject = GameObject.Find("yubi");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 dir = (targetObject.transform.position - transform.position).normalized;
        float vx = dir.x * move;
        float vy = dir.y * move;
        this.transform.Translate(vx/20, vy/20, 0);
        if(targetObject.transform.position.y >= this.gameObject.transform.position.y){
            transform.Translate(0,-0.1f,0);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "yubi")
            Destroy(this.gameObject);
    }
}
