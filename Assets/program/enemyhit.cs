using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyhit : MonoBehaviour
{
   public float insmax;
   public float insmin;
   float move;
   bool run;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = Random.Range(insmin,insmax) / -100;
        transform.Translate(0,move,0);
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
