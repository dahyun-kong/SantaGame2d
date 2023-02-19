using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] StagerData stagdata;

    private Vector3 movedirestion;
    [SerializeField]
    float movespeed, cooltime;
    float curtime;
    [SerializeField] Transform ballPosition;
    [SerializeField] GameObject snowball;

    private Vector2 move;

    float MaxHP = 3;
    float currentHP;
    SpriteRenderer SR;

    private void Awake()
    {
        currentHP = MaxHP;
        SR = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        curtime -= Time.deltaTime;

        bool hascontrol = (movedirestion != Vector3.zero);
        if (hascontrol)
        {
            //뒷걸음으로 좌우 이미지가 달라질 필요 없
            
            var x = Input.GetAxisRaw("Horizontal");
            var y = Input.GetAxisRaw("Vertical");
            movedirestion = (Vector3.up * y) + (Vector3.right * x);
            transform.Translate(new Vector2(x, y) * movespeed * Time.deltaTime);
        }
        // // MovePlay();

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, stagdata.LimitMin.x, stagdata.LimitMax.x),
            Mathf.Clamp(transform.position.y, stagdata.LimitMin.y, stagdata.LimitMax.y));
    }


    public void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        if (input != null)
        {
            movedirestion = new Vector3(input.x, 0f, input.y);

        }
    }
    //인풋필더 invok unity event 받을때 사용
    //public void OnMove(InputAction.CallbackContext context)
    //{
    //    move = context.ReadValue<Vector2>();
    //}

    //public void MovePlay()
    //{
    //    Vector3 movement= new Vector3(move.x, 0f, move.y);
    //    transform.Translate(movement * movespeed * Time.deltaTime,Space.World);

    //}

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        StopCoroutine("HitcolorAnimation");
        StartCoroutine("HitcolorAnimation");

        if (currentHP <= 0)
        {
            Ondie();
        }
    }

    IEnumerator HitcolorAnimation()
    {
        SR.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        SR.color = Color.white;
    }

    private void Ondie()
    {
        Destroy(gameObject);
    }


    private void OnJump()
    {
        if (curtime <= 0)
        { Instantiate(snowball, ballPosition.position, transform.rotation); curtime = cooltime; } 
    }

   
}
 