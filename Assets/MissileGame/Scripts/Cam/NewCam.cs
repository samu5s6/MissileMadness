using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCam : MonoBehaviour
{

    public GameObject player;
    public float cameraDistance = 10.0f;

    public float RotateSmoothTime = 10f;
    private float AngularVelocity = 5f;
    // Use this for initialization
    void Start()
    {
    }

    void LateUpdate()
    {
        transform.position = player.transform.position - player.transform.forward * cameraDistance;
       // transform.LookAt(player.transform.position);
        transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);// player.transform.position + offset ;


    }
    private void FixedUpdate()
    {
        //var target_rot = Quaternion.LookRotation(player.transform.position - transform.position);
        //var delta = Quaternion.Angle(transform.rotation, target_rot);
        //if (delta > 0.0f)
        //{
        //    var t = Mathf.SmoothDampAngle(delta, 0.0f, ref AngularVelocity, RotateSmoothTime);
        //    t = 1.0f - t / delta;
        //    transform.rotation = Quaternion.Slerp(transform.rotation, target_rot, t);
        //}
    }
}

