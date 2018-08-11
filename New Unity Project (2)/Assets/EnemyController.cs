using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyState
{
    Idle,
    Attacking,
    Moving,
    Dead
}
public class EnemyController : MonoBehaviour {
    //用来控制敌人的指令器
    // public GameObject enemy;
    public EnemyState enemyState=EnemyState.Idle;
    public GameObject toFollow;
    public float speed;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (RhythmController.instance.GetCurrentState() == RhythmState.Instruction)
        {
            Vector3 delta = toFollow.transform.position - this.transform.position;

            if (delta.magnitude < 3 && (enemyState == EnemyState.Idle||enemyState==EnemyState.Moving))
            {
                Attack();
            }
        }
        if (RhythmController.instance.GetCurrentState() == RhythmState.Action)
        {
            if (enemyState == EnemyState.Moving)//移动向玩家
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, toFollow.transform.position,speed*Time.deltaTime);
            }
            if (enemyState == EnemyState.Attacking)//扑向玩家
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, toFollow.transform.position, speed * Time.deltaTime);
            }

        }
        
	}
    void Attack()
    {
        Debug.Log("发动了攻击");
        enemyState = EnemyState.Attacking;
        this.GetComponent<Animator>().SetTrigger("Attack_trigger");//播放攻击动画
    }
    void Move()
    {
        Debug.Log("开始了移动");
        this.GetComponent<Animator>().SetBool("IsWalking",true);//播放移动的动画
    }
}
