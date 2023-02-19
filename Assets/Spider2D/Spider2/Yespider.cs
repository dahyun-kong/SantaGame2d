using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yespider : MonoBehaviour
{
    public float time = 1.8f;
    public int iscore = 1;
   
    int i = 1;

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
