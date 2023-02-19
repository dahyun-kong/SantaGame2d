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
        //�⺻ �÷��̾� Ŭ���� ����
        santa = new PlayerDefault();

        isMove = false;
        isJump = false;
        jump = 0;
        bonusPow = 100;
        StatUpdate();
    }
    private void Update()
    {
        // �̵� ����
        isMove = (movedirection != Vector2.zero && movedirection.y == default);
        if(isMove)
        {            
            gameObject.transform.Translate(movedirection * santa.moveSpeed * Time.deltaTime);
        }
        // ���� ����
        if (santa.jumpCount == jump) { isJump = true; }
        else { isJump = false; }
    }

    public void StatUpdate() // �÷��̾� ���� ��������
    {
        santa.playerName = GameObject.FindWithTag("GameController").GetComponent<PlayerScript>().playerName;
        santa.maxHP = GameObject.FindWithTag("GameController").GetComponent<PlayerScript>().maxHP;
        santa.moveSpeed = GameObject.FindWithTag("GameController").GetComponent<PlayerScript>().moveSpeed;
        santa.jumpPower = GameObject.FindWithTag("GameController").GetComponent<PlayerScript>().jumpPower;
        santa.jumpCount = GameObject.FindWithTag("GameController").GetComponent<PlayerScript>().jumpCount;
    }
    void OnMove(InputValue value) // Input System �̵� �Լ�
    {
        movedirection = value.Get<Vector2>();
    }
    void OnJump() // Input System ���� �Լ�
    {   
        if(isJump == false) // �ߺ� ���� ����
        {
            Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.up * santa.jumpPower * bonusPow);
            jump++;
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision) // �ٴ� �浹 �� ���� �ʱ�ȭ
    {
        if (collision.gameObject.tag == "Ground") { jump = 0; }
    }

}
