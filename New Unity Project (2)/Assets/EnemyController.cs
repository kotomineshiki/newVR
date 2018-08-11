using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    //用来控制敌人的指令器
   // public GameObject enemy;
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
           // MoveToward();
        }
	}
    void Attack()
    {
        Debug.Log("发动了攻击");
        this.GetComponent<Animator>().SetTrigger("Attack_trigger");//播放攻击动画
    }
    void MoveToward(Vector3 destination)
    {
        Debug.Log("开始了移动");
        this.GetComponent<Animator>().SetBool("IsWalking",true);//播放移动的动画
    }
}
