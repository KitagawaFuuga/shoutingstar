using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamesectem : MonoBehaviour
{

    GameObject point;
    private bool _isDestroy = false;
    // Start is called before the first frame update
    void Start()
    {
        point = GameObject.Find("ほし");
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnBecameInvisible ()
    {
        GameObject.Destroy(this.gameObject);
    }

}
