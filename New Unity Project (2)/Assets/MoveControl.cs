using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour {
    SteamVR_TrackedObject myController;
    SteamVR_Controller.Device rightDevice;
    public GameObject player;
    public float speed = 23;
	// Use this for initialization
	void Start () {
        myController = this.gameObject.GetComponent<SteamVR_TrackedObject>();
        rightDevice = SteamVR_Controller.Input((int)myController.index);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //检测按键并实现上下左右的移动

        if (this)
        {
        

        }
    }

}
