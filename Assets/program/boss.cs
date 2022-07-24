using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boss : MonoBehaviour
{
    float delat;
    int ran;
    int move = 0;
    public int hp = 30;
    GameObject en;
    void Start()
    {
        en = GameObject.Find("tama");
    }

    // Update is called once per frame
    void Update()
    {
        delat += Time.deltaTime;
       if(delat >= 3)
       {
           Instantiate(en, this.transform.position, Quaternion.identity);
           delat = Random.Range(-1,2);
       }


        if(hp < 10)
        {
            delat = 5;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "star")
        {
            hp -= 1;//hpを-1ずつ変える
        }
        
        if (hp <= 0)//もしhpが0以下なら
        {
            SceneManager.LoadScene("gameclear");//GameOverとコンソールに表示する
        }
    }
}

