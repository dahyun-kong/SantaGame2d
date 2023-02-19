using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respider : MonoBehaviour
{
    public float time = 1.5f;

    public int iscore = 2;
    int i = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", time);
    }


    void Destroy()
    {
        Destroy(this.gameObject);
    }

    private void OnMouseDown()
    {
        RandomSpider.target(i);
        Destroy(this.gameObject);
        RandomSpider.r_score += iscore;
    }

}
