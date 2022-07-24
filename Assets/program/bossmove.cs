using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossmove : MonoBehaviour
{
    public float speed;
    private Vector2 trans;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.position = new Vector2(Mathf.Sin(Time.time) * speed+ trans.x, 7);
    }
}
