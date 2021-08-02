using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camcc : MonoBehaviour
{
    public Transform car;
    public float smoothing = 5f;
    Vector3 offSet;
    public float z;

    // Use this for initialization
    void Awake()
    {
        offSet = transform.position - car.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 camPos = car.position + offSet;
        camPos.z = camPos.z - z;
        transform.position = Vector3.Slerp(transform.position, camPos, smoothing * Time.deltaTime);
       // transform.LookAt(car);
       // Invoke(nameof(look), 0.8f);
    }

    void look()
    {
        transform.LookAt(car);
    }
}
