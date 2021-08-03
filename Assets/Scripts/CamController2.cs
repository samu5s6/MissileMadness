using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController2 : MonoBehaviour
{
    public GameObject player;
    public  Transform camPos;
    public float speed = 10 ;
    public float speed2 = 10;
    //public float cameraDistance = 5f;
    public float Xdist = 3;
    public float Ydist =1;
    public float Zdist = 5;
    // Start is called before the first frame update
    void Start()
    {
        camPos.position = this.transform.position;
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        Vector3 PlayerPOS = player.transform.position;
        GameObject.Find("Main Camera").transform.position = new Vector3(transform.position.x, PlayerPOS.y + Ydist, PlayerPOS.z - Zdist);
       Vector3 po = GameObject.Find("Main Camera").transform.position = new Vector3(transform.position.x, PlayerPOS.y + Ydist, PlayerPOS.z - Zdist);

       // transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4f, 4f), transform.position.y, transform.position.z);

        if (player.transform.position.x > 3 )
        {
            //transform.Translate(Vector3.right * speed * Time.deltaTime);
            
           Vector3 poX= GameObject.Find("Main Camera").transform.position = new Vector3(PlayerPOS.x+Xdist, PlayerPOS.y + Ydist, PlayerPOS.z - Zdist);
            transform.position = Vector3.MoveTowards(po, poX, speed2 * Time.deltaTime);
        }
        else if (player.transform.position.x <-3)
        {
            // transform.Translate(-Vector3.right * speed * Time.deltaTime);
          Vector3 poX2=  GameObject.Find("Main Camera").transform.position = new Vector3(PlayerPOS.x - Xdist, PlayerPOS.y + Ydist, PlayerPOS.z - Zdist);
            transform.position = Vector3.MoveTowards(po, -poX2, speed2 * Time.deltaTime);
        }
        else
        {
            //camPos.position = new Vector3(0, transform.position.y, transform.position.z);
            //transform.position = Vector3.MoveTowards(transform.position, camPos.position, speed2 * Time.deltaTime);
           // GameObject.Find("Main Camera").transform.position = new Vector3(transform.position.x, PlayerPOS.y + Ydist, PlayerPOS.z - Zdist);
        }

    }
}

