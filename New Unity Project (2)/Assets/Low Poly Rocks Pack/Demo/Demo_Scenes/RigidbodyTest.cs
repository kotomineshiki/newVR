using UnityEngine;

public class RigidbodyTest : MonoBehaviour
{

    private Rigidbody rigidbody;

    private Vector3 originalPosition;

    // Use this for initialization

    void Start()
    {

        rigidbody = this.transform.GetComponent<Rigidbody>();

        originalPosition = transform.position;

    }

    void OnCollisionEnter(Collision other)
    {

       
            StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
            {
                this.transform.position = originalPosition;
            },0.0f));

        }


        

        

    }

