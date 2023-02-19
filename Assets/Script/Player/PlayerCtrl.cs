using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCtrl : MonoBehaviour
{
    public PlayerDefault santa;
    private Vector2 movedirection;
    private bool isMove;
    private bool isJump;
    private int bonusPow;
    private int jump;

    private void Start()
    {
        //기본 플레이어 클래스 선언
        santa = new PlayerDefault();

        isMove = false;
        isJump = false;
        jump = 0;
        bonusPow = 100;
        StatUpdate();
    }
    private void Update()
    {
        // 이동 실행
        isMove = (movedirection != Vector2.zero && movedirection.y == default);
        if(isMove)
        {            
            gameObject.transform.Translate(movedirection * santa.moveSpeed * Time.deltaTime);
        }
        // 점프 실행
        if (santa.jumpCount == jump) { isJump = true; }
        else { isJump = false; }
    }

    public void StatUpdate() // 플레이어 설정 가져오기
    {
        santa.playerName = GameObject.FindWithTag("GameController").GetComponent<PlayerScript>().playerName;
        santa.maxHP = GameObject.FindWithTag("GameController").GetComponent<PlayerScript>().maxHP;
        santa.moveSpeed = GameObject.FindWithTag("GameController").GetComponent<PlayerScript>().moveSpeed;
        santa.jumpPower = GameObject.FindWithTag("GameController").GetComponent<PlayerScript>().jumpPower;
        santa.jumpCount = GameObject.FindWithTag("GameController").GetComponent<PlayerScript>().jumpCount;
    }
    void OnMove(InputValue value) // Input System 이동 함수
    {
        movedirection = value.Get<Vector2>();
    }
    void OnJump() // Input System 점프 함수
    {   
        if(isJump == false) // 중복 점프 방지
        {
            Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.up * santa.jumpPower * bonusPow);
            jump++;
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision) // 바닥 충돌 시 점프 초기화
    {
        if (collision.gameObject.tag == "Ground") { jump = 0; }
    }

}
