using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MM : MonoBehaviour
{  
	public float speed=35f;
    public float sidespeed=1f;
    [SerializeField] float rotspeed = -60f;
    public GameObject object1;
	public GameObject object2;
    Vector3 rotVel;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //rot
        rotVel = new Vector3(0, rotspeed, 0);
    }

    void FixedUpdate()
	{
		Vector3 dirction = object1.transform.position - object2.transform.position;

		// Normalize resultant vector to unit Vector.
		dirction = -dirction.normalized;

		// Move in the direction of the direction vector every frame.
		object1.transform.position += dirction * Time.deltaTime * speed;


        object1.transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.65f, 2.1f), transform.position.y, transform.position.z);
        moving();
	}

    void moving()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                rb.AddForce(Vector3.right * touch.deltaPosition.x * sidespeed /** Time.deltaTime*/);
                if (touch.deltaPosition.x > 0.5)
                {
                    StartCoroutine("Rot");
                    StopCoroutine("RotLeft");
                }
                else if (touch.deltaPosition.x < -0.5)
                {
                    StartCoroutine("RotLeft");
                    StopCoroutine("Rot");
                }
            }
        }
    }

    IEnumerator Rot()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Quaternion deltaRotation = Quaternion.Euler(rotVel * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator RotLeft()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Quaternion deltaRotation = Quaternion.Euler(-rotVel * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
