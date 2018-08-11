using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    //用来控制敌人的指令器
    public GameObject enemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            MoveToward();
        }
	}
    void Attack()
    {
        enemy.GetComponent<Animator>().SetTrigger("Attack_trigger");//播放攻击动画
    }
    void MoveToward()
    {
        enemy.GetComponent<Animator>().SetTrigger("Idle_Walk_trigger");//播放移动的动画
    }
}
