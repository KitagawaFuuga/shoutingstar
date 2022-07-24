using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class seisann : MonoBehaviour
{

    Camera ca;
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject boss;
     Vector2 createPos;
    Vector2 createPos2;

    public float RandomLow;
    public float RandomHigh;
    float seconds;
    float seconds2;
    int ran;
    int tan;
    int des;
    // Start is called before the first frame update
    void Start()
    {
        this.ca = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        seconds2 += Time.deltaTime;

        ran = Random.Range(-2,2);
        des = Random.Range(-2,2);
        tan = ran - des;

        float ransama = Random.Range(RandomLow,RandomHigh);
        float ransama2 = Random.Range(RandomLow,RandomHigh);

            if(seconds >= ransama && ca.transform.position.y <= 113)
                {
                    Instantiate(enemy, createPos + new Vector2(ran,9), Quaternion.identity);
                    createPos = createPos + new Vector2(0,13);
                    seconds = 0;
                }

            if(seconds2 >= ransama && ca.transform.position.y <= 113)
                {
                    Instantiate(enemy2, createPos2 + new Vector2(tan, 9), Quaternion.identity);
                    createPos2 = createPos2 + new Vector2(0,13);
                    seconds2 = 0;
                }        

            if(ca.transform.position.y >= 117)
            {
                SceneManager.LoadScene("bosssene");
            }
    }
}
