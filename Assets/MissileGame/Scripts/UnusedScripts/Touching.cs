using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touching : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    private Vector3 targetPosition;
    public float speedmodifier=100;
    public Animator anim;
    private void Start()
    {
        targetPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(transform.localPosition.x >0)
        {
            anim.SetFloat("vertical", 1);
            anim.SetFloat("horizontal", 1f);
        }
        if (transform.localPosition.x < 0)
        {
            anim.SetFloat("vertical", 1);
            anim.SetFloat("horizontal", -1f);
        }


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                 //  targetPosition += Vector3.right * touch.deltaPosition.x * speedmodifier*Time.deltaTime; 
                _rigidbody.AddForce(Vector3.right * touch.deltaPosition.x * speedmodifier /** Time.deltaTime*/);
              
            }
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(targetPosition);
    }
}