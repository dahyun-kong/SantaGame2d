using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buspider : MonoBehaviour
{
    public float time=1f;
    public int iscore = 5;
    
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
