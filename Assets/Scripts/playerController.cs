using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{

    Rigidbody rigidbody;

    // Use this for initialization
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, 10);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, -10);
        }
        else
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector3(-10, rigidbody.velocity.y, rigidbody.velocity.z);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector3(10, rigidbody.velocity.y, rigidbody.velocity.z);
        }
        else
        {
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, rigidbody.velocity.z);
        }
    }
}
