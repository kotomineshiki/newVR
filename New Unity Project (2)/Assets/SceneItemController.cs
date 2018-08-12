using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneItemController : MonoBehaviour {
    public GameObject firstScene;
    public int SceneNumber=1;
    public Vector3 changeScenePosition;
    public GameObject secondScene;
    public GameObject player;
    public List<GameObject> firstSceneObject;
    public GameObject[] secondSceneObject;//包括敌人
    public GameObject[] parList;
    public GameObject[] secondSceneLight;
    public Stack<GameObject> toAdd;
    public bool IsBurning = false;
	// Use this for initialization
	void Start () {
        toAdd = new Stack<GameObject>();

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 delta = player.transform.position - changeScenePosition;//当前玩家位置距离传送点的位置
        if (delta.magnitude < 15&&SceneNumber==1)
        {
            ChangeScene();
        }
        if (RhythmController.instance.GetCurrentState() == RhythmState.Forbidden&&IsBurning==true)
        {
            //禁止火焰燃烧
            LitFlame();        //   KillLight();
            LitLight();
            IsBurning = false;
        }
        if (RhythmController.instance.GetCurrentState() == RhythmState.Action&&IsBurning==false)
        {
            
            KillFlame();
            //    LitLight();
            KillLight();
            IsBurning = true;
        }

	}
    void ChangeScene()
    {
        Debug.Log("ChangeScene");
        firstScene.gameObject.SetActive(false);
        secondScene.gameObject.SetActive(true);
        
        parList = GameObject.FindGameObjectsWithTag("Effect");
        StartCoroutine(StatueStartActing(1));
    }
    IEnumerator StatueStartActing(int i)
    {
        if (i == 1)
        {
            yield return new WaitForSeconds(1.0f);//第一批敌人
            secondSceneObject[0].GetComponent<EnemyController>().isRestricted = false;
            secondSceneLight[0].gameObject.SetActive(true);
         //   secondSceneObject[0].GetComponent<EnemyController>().enemyState = EnemyState.Moving;
        }else if (i == 2)
        {
            yield return new WaitForSeconds(7.0f);//第二批敌人
            secondSceneObject[1].GetComponent<EnemyController>().isRestricted = false;
            secondSceneLight[1].gameObject.SetActive(true);
            //   secondSceneObject[1].GetComponent<EnemyController>().enemyState = EnemyState.Moving;
        }
        else if (i == 3)
        {
            yield return new WaitForSeconds(10.0f);//第三批敌人
            secondSceneObject[2].GetComponent<EnemyController>().isRestricted = false;
            secondSceneObject[3].GetComponent<EnemyController>().isRestricted = false;
            secondSceneLight[2].gameObject.SetActive(true);
            secondSceneLight[3].gameObject.SetActive(true);
            secondSceneLight[4].gameObject.SetActive(true);
            secondSceneLight[5].gameObject.SetActive(true);
            secondSceneLight[6].gameObject.SetActive(true);
         //   secondSceneLight[7].gameObject.SetActive(true);
            //   secondSceneObject[2].GetComponent<EnemyController>().enemyState = EnemyState.Moving;
            //   secondSceneObject[3].GetComponent<EnemyController>().enemyState = EnemyState.Moving;
        }
        if (i < 3)
            StartCoroutine(StatueStartActing(i + 1));

    }
    void KillLight()
    {
        foreach(var i in secondSceneLight)
        {
            if (i.gameObject.activeInHierarchy == true)
            {
                toAdd.Push(i);
                i.gameObject.SetActive(false);
            }
        }
    }
    void LitLight()
    {
        while (toAdd.Count != 0)
        {
            toAdd.Pop().SetActive(true);
        }
    }
    void KillFlame()
    {
        Debug.Log("killed");
        foreach(var i in parList)
        {
            i.GetComponent<ParticleSystem>().Pause();
        }
    }
    void LitFlame()
    {
        Debug.Log("lit");
        foreach(var i in parList)
        {
            i.GetComponent<ParticleSystem>().Play();
        }
    }
}
