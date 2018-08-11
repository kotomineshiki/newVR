using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Idle,
    Moving,
    Attacking,
    Dead
}
public class EnemyController : MonoBehaviour {
    //用来控制敌人的指令器
    public EnemyState enemyState=EnemyState.Idle;
    public GameObject enemy;
    public float speed = 10;
    public GameObject toFollow;
    public Vector3 Destination;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 delta = toFollow.transform.position - enemy.transform.position;
        if (RhythmController.instance.GetCurrentState() == RhythmState.Instruction)//指令时刻
        {
            if (enemyState == EnemyState.Idle)
            {

            }
        }
        if (RhythmController.instance.GetCurrentState() == RhythmState.Action)//只会在action时段执行动作
        {
            if (enemyState == EnemyState.Moving)
            {
                this.transform.position += Time.deltaTime * speed;
            }
        }

        if (delta.magnitude < 1f)//距离充分近，可以发动攻击了
        {
            Attack();
        }
	}

    void Attack()
    {
        enemy.GetComponent<Animator>().SetTrigger("Attack_trigger");//播放攻击动画
    }
    void MoveToward(Vector3 input)
    {
        Destination = input;
        enemy.GetComponent<Animator>().SetTrigger("Idle_Walk_trigger");//播放移动的动画
    }
}
