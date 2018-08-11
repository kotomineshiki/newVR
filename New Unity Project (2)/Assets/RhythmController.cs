using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum RhythmState
{
    Instruction,//运行发送指令、允许执行动作
    Action,//允许执行动作
    Forbidden//禁止执行动作，且禁止执行指令
}
public class RhythmController : MonoBehaviour {
    /*这个类用来管理鼓点节奏
     *其他类会通过查询这个类的状态来判断当前处于什么状态：是否可以操作玩家
     * 
     */
    public AudioSource music;//disco
    public static RhythmController instance;//简单单例模式
    public RhythmState currentState=RhythmState.Forbidden;
    public float repeatTime;//重复时间：时间周期
    public float speed;

    public GameObject banner;
    public GameObject clock;
    public GameObject flag;

    public int turn=1;
    public float end;
    public float instructionTolerate;
    public float actionTolerate;
	// Use this for initialization
	void Awake () {
        instance = this;
	}
    void Start()
    {
        speed = (end) / repeatTime;
        music.Play();
    }

    void Update()
    {
        // Debug.Log(clock.transform.position);
        Debug.Log(clock.transform.localPosition.x + "dfasf" + end );

        if (turn == 1)
        {
            if (clock.transform.localPosition.x < end)//去程
            {
                clock.GetComponent<RectTransform>().localPosition += new Vector3(1, 0, 0)  * speed * Time.deltaTime;

            }else
            {
                turn = -1;
                end = -end;            }
        }else
        {
            if(turn == -1)
            {
                if (clock.transform.localPosition.x > end)//回程
                {
                    clock.GetComponent<RectTransform>().localPosition -= new Vector3(1, 0, 0)   * speed * Time.deltaTime;
                }else
                {
                    turn = 1;
                    end = -end;
                }
            }
        }
        float delta = Mathf.Abs(clock.transform.localPosition.x - flag.transform.localPosition.x) ;
    //    Debug.Log(delta);
        if (delta<instructionTolerate)
        {
            currentState = RhythmState.Instruction;
        }else if(delta<actionTolerate)
        {
            currentState = RhythmState.Forbidden;
            if(clock.transform.position.x - flag.transform.position.x>0&&turn==1)
                currentState = RhythmState.Action;
            if (clock.transform.position.x - flag.transform.position.x < 0 && turn == -1)
                currentState = RhythmState.Action;
        }else
        {
            currentState = RhythmState.Forbidden;
        }

    }
    void FixedUpdate () {

	}
    public RhythmState GetCurrentState()
    {
        return currentState;
    }
    
}
