using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // 기본 정보 입력
    public string playerName;
    public int maxHP;
    public float moveSpeed;
    public float jumpPower;
    public int jumpCount;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    public void GameStatusUpdate() // 게임 상태 업데이트
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerCtrl>().StatUpdate();
    }
}
public class PlayerDefault : MonoBehaviour //플레이어 기본 클래스
{
    public string playerName = "default";
    public int maxHP = 0;
    public float moveSpeed = 0;
    public float jumpPower = 0;
    public int jumpCount = 0;
}
