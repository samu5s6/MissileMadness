using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTouch : MonoBehaviour
{
    public GameObject Joystick;
   // Vector3 touchstart;
    public Camera cam;
   // public float groundZ = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //private Vector3 GetWorldPosition(float z)
    //{
    //    Ray mousepos = cam.ScreenPointToRay(Input.mousePosition);
    //    Plane ground = new Plane(Vector3.forward, new Vector3(0, 0, z));
    //    float distance;
    //    ground.Raycast(mousepos, out distance);
    //    return mousepos.GetPoint(distance);


    //}
    // Update is called once per frame
    void Update()
    {
        //if(Input.GetMouseButtonDown(0))
        //{
        //    touchstart = GetWorldPosition(groundZ);
            
        //            Instantiate(Joystick, transform.position, Quaternion.identity);
        //}


        if (Input.GetMouseButtonDown(0))
        {
            Vector3 touchpos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
            Instantiate(Joystick, touchpos, Quaternion.identity);
        }

    }
}
