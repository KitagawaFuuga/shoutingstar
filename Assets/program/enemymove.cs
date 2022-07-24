using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemymove : MonoBehaviour
{

    float runTime;
    Renderer targetRenderer; // 判定したいオブジェクトのrendererへの参照
    public int hp = 5;
    public float x_speed, y_speed = 10f, delat = 1f;
    public GameObject enemybullet;
    private Vector2 pos;[SerializeField]
    private Rigidbody2D rb;
    public AudioClip sound;
    public AudioClip sound2;
    public AudioClip sound3;
    AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetRenderer = GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();	
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        if (targetRenderer.isVisible){
        rb.velocity = new Vector2(x_speed,y_speed);
            runTime += Time.deltaTime;
            if(delat<= runTime)
                {
                Instantiate(enemybullet, pos, Quaternion.identity);
                runTime = 0f;
                audioSource.PlayOneShot(sound);
                }
        
        }       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "star")//衝突した相手のタグがEnemyなら
        {
            hp -= 1;//hpを-1ずつ変える
            audioSource.PlayOneShot(sound2);
        }
        
        if (hp <= 0)//もしhpが0以下なら
        {
            Destroy(this.gameObject);//自分自身を消す
            audioSource.PlayOneShot(sound3);
        }
        
    }
    
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    
}
