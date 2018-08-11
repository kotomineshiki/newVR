using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CreateDropStone : MonoBehaviour {

    public GameObject stone;
    public float x;
    public float y;
    public float z;
    public int range;


	// Use this for initialization
	void Start () {
        InvokeRepeating("Drop",1f,0.01f);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Drop()
    {
        System.Random rand = new System.Random();
        int value1 = rand.Next(range*-1,range);
        int value2 = rand.Next(range * -1, range);
        GameObject first = Instantiate(stone);
        first.transform.position = new Vector3(x+ value1, y, z+ value2);
    }
}
