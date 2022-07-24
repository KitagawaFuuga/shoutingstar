using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameContllre : MonoBehaviour
{
    public float speed = 100.0f;
    public AudioClip sound;
    AudioSource audioSource;
    GameObject star;
    // Start is called before the first frame update
    void Start()
    {
        star = GameObject.Find("ほし");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(h,v).normalized;
        
        this.MovingRestriction();

        GetComponent<Rigidbody2D>().velocity = direction * speed;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(star, this.transform.position, Quaternion.identity);
            audioSource.PlayOneShot(sound);
        }
    }
    
    private void MovingRestriction()
    {
        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -10f, 200f);
        pos.y = Mathf.Clamp(pos.y, -100f, 100f);
        transform.position = new Vector2(pos.x, pos.y);
    }


}
