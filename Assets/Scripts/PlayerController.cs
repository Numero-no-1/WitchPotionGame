using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;
    private Animator myAnim;

    [SerializeField]
    private float speed = 0;

    private float attackTime = 0.25f;
    private float attackCounter = 0.25f;
    private bool isAttacking;


    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    void Update()
    {
        //myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))/*.normalized*/ * speed * Time.deltaTime;     // 움직임 구현  normalized-대각선방향 움직일때 더 빨라지는것 막아줌

        myAnim.SetFloat("moveX", myRB.velocity.x);
        myAnim.SetFloat("moveY", myRB.velocity.y);          // 움직이는 애니메이션 구현

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));         // 움직임이 멈췄을때의 방향 애니메이션 유지
        }

        if (isAttacking)
        {
            myRB.velocity = Vector2.zero;
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                myAnim.SetBool("isAttacking", false);
                isAttacking = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            attackCounter = attackTime;
            myAnim.SetBool("isAttacking", true);
            isAttacking = true;
        }
    }

    private void FixedUpdate()
    {
        myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))/*.normalized*/ * speed * Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.tag == "Item")
        {
            Debug.Log("아이템을 먹었다.");
            Destroy(other.gameObject);
        }

        else if (other.tag == "Home")
        {
            SceneManager.LoadScene("House");
        }
        
        else if (other.tag == "Main")
        {
            SceneManager.LoadScene("Main");
        }
    }

}
