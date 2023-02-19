using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Mgr : MonoBehaviour
{
    public GameObject ui;
   

    // Start is called before the first frame update
    void Start()
    {
        ui.SetActive(false);
    }

   // Update is called once per frame
    void Update()
    {
        //if (SceneData.S_instance. missionCrear == "crear")
        //{
        //    ui.SetActive(true);
        //    SceneData.S_instance.missionCrear = "";
        //}
        //if (SceneData.S_instance.Failed == "failed")
        //{
        //    Instantiate(Resources.Load("FailedUI"));
            
        //    SceneData.S_instance.Failed = "";
        //}
    }

}
