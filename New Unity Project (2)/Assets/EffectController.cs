using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectController : MonoBehaviour {
    public GameObject OnDeadEffect;
    public Image middleFlag;
    public HandShake rightHand;
    public HandShake leftHand;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnRhym(Direction input)//当符合节奏的时候
    {
        middleFlag.GetComponent<Animation>().Play();
        if (input == Direction.Front)
        {
            rightHand.Shake(0.18f);
            leftHand.Shake(0.18f);
        }
        if (input == Direction.Left)
        {
            leftHand.Shake(0.18f);
        }
        if (input == Direction.Right)
        {
            rightHand.Shake(0.18f);
        }
    }
    public void Die(GameObject goDie)
    {
        Debug.Log("自信失望");
        var p = Instantiate(OnDeadEffect);
        p.transform.position = goDie.transform.position;
        //OnDeadEffect.Play();
        rightHand.Shake(0.3f);
        goDie.gameObject.SetActive(false);
    }
}
