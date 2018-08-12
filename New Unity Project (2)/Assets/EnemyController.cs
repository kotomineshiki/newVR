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
    public GameObject model;
    public GameObject toFollow;
    public Vector3 destination;
    public float speed;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (RhythmController.instance.GetCurrentState() == RhythmState.Instruction)
        {
            Vector3 delta = toFollow.transform.position - this.transform.position;

            if (delta.magnitude < 3 && (enemyState == EnemyState.Idle||enemyState==EnemyState.Moving))//靠的很近时
            {
                Attack(toFollow.transform.position);
            }
            if((delta.magnitude>3&&delta.magnitude<30)
                && (enemyState == EnemyState.Idle||enemyState ==EnemyState.Moving||enemyState==EnemyState.Attacking))//靠的中等程度近时
            {//触发移动、调整行走
                Move(toFollow.transform.position);
            }
        }
        if (RhythmController.instance.GetCurrentState() == RhythmState.Action)
        {


            if (enemyState == EnemyState.Moving)//移动向玩家
            {
                // this.transform.rotation.(destination);//保证永远朝向玩家
                this.transform.forward = (destination - this.transform.position);
                //Vector3.RotateTowards()
                this.transform.position = Vector3.MoveTowards(this.transform.position, destination,speed*Time.deltaTime);
                if (model.GetComponent<Animation>().IsPlaying("newIdle") == false) model.GetComponent<Animation>().Play("newIdle");

            }
            if (enemyState == EnemyState.Attacking)//扑向玩家
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, destination, speed * Time.deltaTime);
                model.GetComponent<Animation>().Play("newIdle");
                //if()this.GetComponent<Animator>().SetTrigger("Attack_trigger");//播放攻击动画
            }

        }
        if (RhythmController.instance.GetCurrentState() == RhythmState.Forbidden)
        {
            StopMovement();
        }
        
	}
    void Attack(Vector3 dest)//攻击将会扑向该位置
    {
        Debug.Log("发动了攻击");
        enemyState = EnemyState.Attacking;
        destination = dest;
        //model.GetComponent<Animator>().SetTrigger("Attack_trigger");//播放攻击动画
    }
    void Move(Vector3 dest)
    {
        Debug.Log("开始了移动");
        destination = dest;
       // model.GetComponent<Animator>().SetBool("IsWalking",true);//播放移动的动画
    }
    void StopMovement()
    {//在这一个函数中应当停止动画和动作
        if (model.GetComponent<Animation>().isPlaying == true) ;
            //model.GetComponent<Animation>().Stop();
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("碰撞");
        if (other.tag == "Player")
        {
            Debug.Log("PlayerLose");
        }
        if (other.tag == "Sword")
        {
            Debug.Log("sword hit");
        }
    }
}
