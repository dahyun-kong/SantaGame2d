using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class RandomSpider : MonoBehaviour
{
    [Tooltip("기준점수")]
    public static int r_score;
    [Tooltip("거미프리팹")]
    public GameObject[] spider;

    public BoxCollider2D area;
    [Tooltip("진행 시간")]
    public int time=2;

    public List<string> objList = new List<string>();
    public AudioSource audio;
    public AudioClip[] clip=new AudioClip[2];
    bool on;
    
    public Text M_score;

    public static System.Action<int> target;

    private void Awake()
    {
        target = AudioPlay;
    }
    private void Start()
    {
        audio = GetComponent<AudioSource>();

        area = GetComponent<BoxCollider2D>();//지정면적
        StartCoroutine("Spawn", time);

    }
    private IEnumerator Spawn(float time)
    {
        if (!on)
        {
         yield return new WaitForSeconds(time); 
        Vector3 spawnPos = GetRandomPosition(); 
        int randomIndex = Random.Range(0, spider.Length);
        
        GameObject instance = Instantiate(spider[randomIndex], spawnPos, Quaternion.identity);
            target(0);
          
            objList.Add(instance.name); 
       
            StartCoroutine("DeSpawn", time);
        }
        

    }

    private IEnumerator DeSpawn(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine("Spawn", time);

    }

    //BoxCollider2D 내의 랜덤한 위치를 return
    private Vector2 GetRandomPosition()
    {
        Vector2 basePosition = transform.position;  //오브젝트의 위치
        Vector2 size = area.size;                   //box colider2d, 즉 맵의 크기 벡터

        //x, y축 랜덤 좌표 얻기
        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);

        Vector2 spawnPos = new Vector2(posX, posY);

        return spawnPos;
    }
    
    private void Update()
    {
        if(!on)
        {
            M_score.text = "s:" + r_score;

            if (objList.Count >= 10)
            {
                SceneData.S_instance.FailedUi("failed");
                on = !on;
            }
            if (r_score >= 20)
            {
                SceneData.S_instance.MissionCrear("crear");
                on = !on;
            }
        }
       
    }

    public void AudioPlay(int i)
    {
        audio.clip = clip[i];

        audio.Play();
    }
    
}
   

