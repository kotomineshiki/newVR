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
    public static RhythmController instance;//简单单例模式
    public RhythmState currentState=RhythmState.Forbidden;
    public float repeatTime;//重复时间：时间周期
    public float instructionRate;//指令时间比例
    public float actionRate;//执行时间比例

    public GameObject banner;
    public GameObject clock;
    public GameObject flag;


	// Use this for initialization
	void Awake () {
        instance = this;
	}
    void Start()
    {

    }

    void Update()
    {
        currentState = RhythmState.Instruction;
        if (Input.GetButtonDown("Fire1"))
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
