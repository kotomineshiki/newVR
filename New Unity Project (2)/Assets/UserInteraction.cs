using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Direction{
    Front,
    Left,
    Right,
    Back
}
public class UserInteraction : MonoBehaviour {

    /*这个类是用来封装各个玩家对角色的操纵的
     * 
     */
    public Text test;//颜色表示器
    public int testCount=0;//测试用的计数器
    public RhythmState currentRhythmState;
    public GameObject playerActionController;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
             currentRhythmState = RhythmController.instance.GetCurrentState();
        //currentRhythmState = RhythmState.Instruction;//测试
        if (currentRhythmState == RhythmState.Instruction)
        {
            //test.color = new Color(0, 0, 1);
            //允许有指令输入的时候
            if()
            RhythmController.instance.circle.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 1);
        }
        else if (currentRhythmState == RhythmState.Action)
        {//允许世界上的各个要素开始运动的时候
         //   Debug.Log("YEs");
            RhythmController.instance.circle.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0);
        }
        else
        {
            StopAllAction();
            RhythmController.instance.circle.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0);
        }


	}
    public void GetMovement(GestureType g)
    {
        Debug.Log("receiving " + g);
        if (g == GestureType.Right_Left)
        {
            Move(Direction.Left);
        }
        if (g == GestureType.Left_Right)
        {
            Move(Direction.Right);
        }
    }
    void FixedUpdate()//执行动作
    {
        
    }
    private void Move(Direction direction)
    {//操作玩家进行移动
        Debug.Log("Move" + direction);
        //  testCount++;
        //    test.text = testCount.ToString();
        //此处应该还要计算修正过的方向；
       
        playerActionController.GetComponent<PlayerActionManager>().PlayerMove(direction);//移动
    }
    private void Attack()
    {

    }
    private void StopAllAction()//停止一切需要静止的活动
    {
        playerActionController.GetComponent<PlayerActionManager>().ForceStop();//强制停止
    }
}
