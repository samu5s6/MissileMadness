using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject player;
    public  Transform camPos;
    public float speed = 10 ;
    public float speed2 = 10;
    public float Xdist = 0;
    public float Ydist =1;
    public float Zdist = 5;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camPos.position = this.transform.position;
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        Vector3 PlayerPOS = player.transform.position;
        /*GameObject.Find("Camera").*/transform.position = new Vector3(transform.position.x, PlayerPOS.y + Ydist, PlayerPOS.z - Zdist);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4, 4), transform.position.y, transform.position.z);

        if (player.transform.position.x > 2.3)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x >= 4)
            {
                speed = 0;
            }
            else
            {
                speed = speed2;
            }

        }
        else if (player.transform.position.x < -2.3)
        {

            transform.Translate(-Vector3.right * speed * Time.deltaTime);

            if (transform.position.x <= -4)
            {
                speed = 0;
            }
            else
            {
                speed = speed2;
            }
        }
        else
        {
            camPos.position = new Vector3(0, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, camPos.position, speed2 * Time.deltaTime);
    }

}

    private void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject.tag=="Finish")
       // GameObject.Find("Camera").transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
       // rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}

