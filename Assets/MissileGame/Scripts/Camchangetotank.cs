using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camchangetotank : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        cam1.SetActive(false);
        cam2.SetActive(true);
    }
}
