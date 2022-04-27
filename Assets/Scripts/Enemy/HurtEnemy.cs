using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive = 2;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            //Destroy(other.gameObject);      // 테스트한것 히트박스에 맞으면 죽음
            EnemyHealthManager eHealthManager;
            eHealthManager = other.gameObject.GetComponent<EnemyHealthManager>();
            eHealthManager.HurtEnemy(damageToGive);
        }
    }
}
