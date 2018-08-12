using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour {
    public ParticleSystem OnDeadEffect;
    public HandShake hand;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Die(GameObject goDie)
    {
        Debug.Log("自信失望");
        var p = Instantiate(OnDeadEffect);
        p.transform.position = goDie.transform.position;
        OnDeadEffect.Play();
        hand.Shake(0.3f);
        goDie.gameObject.SetActive(false);
    }
}
