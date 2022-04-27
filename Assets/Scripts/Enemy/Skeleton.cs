using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    public Transform homePos;
    

    [SerializeField]
    private float speed = 0f;
    [SerializeField]
    private float maxRange = 0;
    [SerializeField]
    private float minRange = 0;

    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController>().transform;
    }

    
    void Update()
    {
        // 범위를 지정해줘서 따라오게 함. 플레이어와 근접했을때만 따라오도록
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            FollowPlayer();
        }
        else if(Vector3.Distance(target.position, transform.position) >= maxRange)
        {
            GoHome();
        }
    }

    // 몬스터가 플레이어를 쫓아오게 함
    public void FollowPlayer()
    {
        myAnim.SetBool("isMoving", true);       // 움직임
        myAnim.SetFloat("moveX", target.position.x - transform.position.x);
        myAnim.SetFloat("moveY", target.position.y - transform.position.y);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    // 플레이어가 범위에서 벗어난다면 정해진 구역으로 돌아가게함
    public void GoHome()
    {
        myAnim.SetFloat("moveX", homePos.position.x - transform.position.x);
        myAnim.SetFloat("moveY", homePos.position.y - transform.position.y);
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, homePos.position) == 0)        // 추적하지 않을때 애니메이션 멈춤
        {
            myAnim.SetBool("isMoving", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)         // 몬스터 공격했을때 넉백주기
    {
        if (other.tag == "MyWeapon")
        {
            Vector2 difference = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        }
    }
}
