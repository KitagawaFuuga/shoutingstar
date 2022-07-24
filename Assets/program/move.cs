using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class move : MonoBehaviour
{

    [SerializeField] float gamemove;
    int Hp = 5;
    Camera ca;
    [SerializeField] AudioClip sound;
    AudioSource audioSource;

    GameObject my;
    public Text HpText;
    
    [SerializeField] float flashInterval;
    [SerializeField] int loopCount;
    SpriteRenderer sp;
    BoxCollider2D bc2d;
    bool isHit;
    
    enum STATE
    {
        NOMAL,
        DAMAGE,
        MUTEKI
    }
    
    STATE state;
    // Start is called before the first frame updateS
    void Start()
    {
        ca = Camera.main;
        my = GameObject.Find("yubi");
        sp = GetComponent<SpriteRenderer>();
        bc2d = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate (0, gamemove, 0);

        if(ca.transform.position.y >= 120)
            gamemove = 0;
        if(my.transform.position.y >= 118) 
            gamemove = 0;
            
        if(ca.transform.position.y >= 117)
        {
            SceneManager.LoadScene("bosssene");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        HpText.text = string.Format("HP : {0}", Hp);
        if(isHit){
            return;
        }
        
        if(other.gameObject.tag == "enemy" || other.gameObject.tag == "Tama"){
            if(state == STATE.MUTEKI){
                return;
            }
            Hp = Hp - 1;
            state = STATE.MUTEKI;
            audioSource.PlayOneShot(sound);
            StartCoroutine(Hit());
        }
        
        if(Hp <= 0){
            SceneManager.LoadScene("gameover");
        }
    }
    
    IEnumerator Hit()
    {
        isHit = true;
        for(int i = 0; i < loopCount; i++)
        {
            yield return new WaitForSeconds(flashInterval);
            sp.enabled = false;
            yield return new WaitForSeconds(flashInterval);
            sp.enabled = true;
        }
        isHit = false;
        state = STATE.NOMAL;
    }
}
