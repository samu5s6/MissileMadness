using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachStuffs : MonoBehaviour
{
    [SerializeField] GameObject sphere;
    [SerializeField] GameObject cube;

    bool AttachCalled = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(AttachCalled == true)
        {
            Attach();
        }
    }
    void Attach()
    {

    }
}
