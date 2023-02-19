using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // �⺻ ���� �Է�
    public string playerName;
    public int maxHP;
    public float moveSpeed;
    public float jumpPower;
    public int jumpCount;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    public void GameStatusUpdate() // ���� ���� ������Ʈ
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerCtrl>().StatUpdate();
    }
}
public class PlayerDefault : MonoBehaviour //�÷��̾� �⺻ Ŭ����
{
    public string playerName = "default";
    public int maxHP = 0;
    public float moveSpeed = 0;
    public float jumpPower = 0;
    public int jumpCount = 0;
}
