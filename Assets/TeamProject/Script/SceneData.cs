using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.SceneManagement;


public class SceneData : ScriptableObject
{
    private const string settingFileDirectory = "Assets/Resources";
    private const string settingFilePath = "Assets/Resources/SceneData.asset";

    private static SceneData s_instance;
    public static SceneData S_instance
    {
        get
        {
            if (s_instance != null)
            {
                return s_instance;
            }
            s_instance = Resources.Load<SceneData>("SceneData");
#if UNITY_EDITOR
            if (s_instance == null)
            {
                if (!AssetDatabase.IsValidFolder(settingFileDirectory))
                {
                    AssetDatabase.CreateFolder("Assets", "Resources");
                }
                s_instance = AssetDatabase.LoadAssetAtPath<SceneData>(settingFilePath);

                if (s_instance == null)
                {
                    s_instance = CreateInstance<SceneData>();
                    AssetDatabase.CreateAsset(s_instance, settingFilePath);
                }
            }
#endif
            return s_instance;
        }
    }

   
        [SerializeField]
        List<AsyncOperation> sceneToload = new List<AsyncOperation>();
        [SerializeField]
        public string missionCrear;
        [SerializeField]
        public string Failed;
        public void startGame(string scenename)
        {
            sceneToload.Add(SceneManager.LoadSceneAsync("BaseScene"));
            sceneToload.Add(SceneManager.LoadSceneAsync(scenename, LoadSceneMode.Additive));
        }



        public void Lobby()
        {
            SceneManager.LoadScene("Lobby");
        }
        public void Exit()
        {
            Application.Quit();
    }

    public void FailedUi(string failed)
    {
        if (failed == "failed")
        {
            Instantiate(Resources.Load("FailedUI"));

            SceneData.S_instance.Failed = "";
        }

    }

    public void MissionCrear(string crear)
    {
        if (crear == "crear")
        {

            Instantiate(Resources.Load("CrearUI"));
            SceneData.S_instance.missionCrear = "";
        }

    }

}
