using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeveCtrl : MonoBehaviour
{


    public GameObject emu;

    //int icount = 10;
    //public BoxCollider2D area;
    //private List<GameObject> emulist = new List<GameObject>();

    //// Start is called before the first frame update
    //void Start()
    //{
    //    area = GetComponent<BoxCollider2D>();
    //    StartCoroutine("Spawn", 2);
    //}

    ////// Update is called once per frame
    ////void Update()
    ////{

    ////}

    //IEnumerator Spawn(float delaytime)
    //{
    //    for (int i = 0; i < icount; i++)
    //    {
    //        Vector3 spawnpos = Getrandomposition();
    //        GameObject instance = Instantiate(emu, spawnpos, Quaternion.identity);
    //        emulist.Add(instance);
    //    }
    //    area.enabled = false;
    //    yield return new WaitForSeconds(delaytime);
    //    for (int i = 0; i < icount; i++)
    //    {
    //        Destroy(emulist[i].gameObject);

    //    }
    //    emulist.Clear();
    //    area.enabled = true;
    //    StartCoroutine("Spawn", 2);

    //}
    //private Vector2 Getrandomposition()
    //{
    //    Vector2 basePosition = transform.position;
    //    Vector2 size = area.size;
    //    float posX = basePosition.x + Random.Range(-size.x/2f, size.x / 2f);
    //    float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);

    //    Vector2 spawnpos = new Vector2(posX, posY);
    //    return spawnpos;
    //}
    //----------------------------------------------------------------
    //float currTime;

    //// �ݺ��Ǵ� �۾��̹Ƿ� ������Ʈ �Լ� �ȿ��� �ڵ带 �Է��Ѵ�.
    //void Update()
    //{
    //    // �ð��� �帣�� ������ش�.
    //    currTime += Time.deltaTime;

    //    // ������Ʈ�� ���ʸ��� ������ ������ ���ǹ����� �����. ���⼭�� 10�ʷ� �ߴ�.
    //    if (currTime > 1)
    //    {
    //        // x,y,z ��ǥ���� ���� �ٸ� �������� �����ϰ� ���������� �������.
    //        //float newX = Random.Range(-10f, 10f), newY = Random.Range(-50f, 50f), newZ = Random.Range(-100f, 100f);

    //        // ������ ������Ʈ�� �ҷ��´�.
    //        GameObject monster = Instantiate(emu);

    //        // �ҷ��� ������Ʈ�� �����ϰ� ������ ��ǥ������ ��ġ�� �ű��.
    //        emu.transform.position = Getrandomposition();

    //        // �ð��� 0���� �ǵ����ָ�, 10�ʸ��� �ݺ��ȴ�.
    //        currTime = 0;
    //    }
    //}
    //private Vector2 Getrandomposition()
    //{
    //    Vector2 basePosition = transform.position;
    //    Vector2 size = area.size;
    //    float posX = basePosition.x + Random.Range(-size.x/2f, size.x / 2f);
    //    float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);

    //    Vector2 spawnpos = new Vector2(posX, posY);
    //    return spawnpos;
    //}

    public float spRangeX = 20f;
    public float spRangeY = 20f;

    private void Start()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spRangeX, spRangeX),spRangeY, 0);
        Instantiate(emu, spawnPos, emu.transform.rotation);
    }


}
