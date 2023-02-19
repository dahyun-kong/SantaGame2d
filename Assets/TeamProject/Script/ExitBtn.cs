using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBtn : MonoBehaviour
{
    // Start is called before the first frame update
   public void OnExit()

    {
        SceneData.S_instance.Exit();
    }
    public void OnLobby()

    {
        SceneData.S_instance.Lobby();
    }

}
