using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipBtn : MonoBehaviour
{
   
    public void SkipOn(string name)
    {
       SceneData.S_instance.startGame(name); 
    }
}
