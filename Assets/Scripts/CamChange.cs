using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamChange : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject multiplier;
    CamController cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CamController>();
        cam2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            multiplier.SetActive(true);
            // cam2.SetActive(true);
            //cc.camStop();
            //cam1.SetActive(false);
            // cam3.SetActive(true);
            Invoke("cam", 0.1f);
        }
    }
    void cam()
    {
        cam2.SetActive(false);
        cam1.SetActive(false);
        cam3.SetActive(true);
    }




}
