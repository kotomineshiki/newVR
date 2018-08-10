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

    public GameObject circle;
    public GameObject mark;


	// Use this for initialization
	void Awake () {
        instance = this;
	}
    void Start()
    {
        //StartCoroutine(CountState());
    }
   /* IEnumerator CountState()
    {
        if (currentState == RhythmState.Instruction)
        {
             yield return new WaitForSeconds(instructionTime);
            currentState = RhythmState.Action;
        }else if(currentState==RhythmState.Action)
        {
             yield return new   WaitForSeconds(actionTime);
            currentState = RhythmState.Forbidden;
        }
        else
        {
            yield return  new WaitForSeconds(repeatTime-instructionTime-actionTime);
            currentState= RhythmState.Instruction;
        }
        StartCoroutine(CountState());//下一个时间状态
    }*/
    // Update is called once per frame
    void Update()
    {
        circle.transform.RotateAround(mark.transform.position, new Vector3(0, 0, 1), (360 / repeatTime) * Time.deltaTime);
        float tempz = circle.transform.rotation.eulerAngles.z < 0 ? circle.transform.rotation.eulerAngles.z + 360 : circle.transform.rotation.eulerAngles.z;//使得角度变成连续的
        if (tempz < instructionRate * 360&& tempz>= 0)//0-180*0.2都是指令时间，具体可以平移
        {
            currentState = RhythmState.Instruction;//命令时间
        }else if(tempz > instructionRate * 360 && tempz <360*(instructionRate+actionRate))//180*(0.2)-180*(0.2+0.3)行动时间
        {
            currentState = RhythmState.Action;//指令时间
        }else
        {
            currentState = RhythmState.Forbidden;//静止时间
        }
    }
    void FixedUpdate () {
        //钟摆.transform.RotateAround(标.transform.position, new Vector3(0, 0, 1), 0);

       // circle.transform.LookAt(mark.transform, new Vector3(0, 0, 1));
	}
    public RhythmState GetCurrentState()
    {
        return currentState;
    }
    
}
