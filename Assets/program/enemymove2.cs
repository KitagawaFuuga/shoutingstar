using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove2 : MonoBehaviour
{

    public float spee;
    int point;

    private Vector2 tran;
    GameObject en;
    GameObject me;
    float dela;
    float desdela;
    
    // Start is called before the first frame update
    void Start()
    {
        tran = transform.position;
        en = GameObject.Find("tama");
        me = GameObject.Find("敵(2)");
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = new Vector2(Mathf.Sin(Time.time) * spee+ tran.x, tran.y);
       dela += Time.deltaTime;
       if(dela >= 0)
       {
           Instantiate(en, this.transform.position, Quaternion.identity);
           dela = Random.Range(-3,-0.5f);
       }
    }

    public void inster()
    {
        desdela += Time.deltaTime;
        if(desdela >= 5)
            Instantiate(me, this.transform.position, Quaternion.identity);
    }
}
