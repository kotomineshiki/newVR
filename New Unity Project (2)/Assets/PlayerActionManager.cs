using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerState
{
    Idle,
    Moving,
    Attacking
}
public class PlayerActionManager : MonoBehaviour {
    /*
     *这个类管理玩家的动作
     */
    public GameObject player;
    public GameObject playerEye;
    public float speed=2f;//玩家移动的速度
    public PlayerState playerState;
    public Vector3 towards=new Vector3(0,0,0);//要移动往的方向
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (playerState == PlayerState.Moving)
        {
            player.transform.position += towards * speed*Time.deltaTime;
     //       Debug.Log("正在移动");
        }
	}
    public void PlayerMove(Direction inputDirection)
    {
       
     //   Debug.Log(playerEye.transform.forward);//当前朝向
        if (inputDirection == Direction.Left)
        {

            towards =Quaternion.AngleAxis(-90,Vector3.up)* playerEye.transform.forward;
            Debug.Log(towards);
        }
        if (inputDirection == Direction.Right)
        {
            towards = Quaternion.AngleAxis(90, Vector3.up) * playerEye.transform.forward;
        }
        if (inputDirection == Direction.Front)
        {
            towards = new Vector3(-1, 0, 0);
        }
        if (inputDirection == Direction.Back)
        {
            towards = new Vector3(-1,0,0);
        }
        playerState = PlayerState.Moving;//切换到运动状态 
    }
    public void ForceStop()//停止当前玩家执行的一切活动
    {
        playerState = PlayerState.Idle;
        towards = new Vector3(0, 0, 0);
    }
}
