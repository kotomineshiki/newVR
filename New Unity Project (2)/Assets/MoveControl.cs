using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //检测按键并实现上下左右的移动

        if (Input.GetButton("Fire1"))
        {

            this.transform.position += Time.deltaTime * 4f * new Vector3(0, 0, 1);
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("yes");
        Destroy(collision.gameObject);
    }

    
}
