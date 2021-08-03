using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMoveMod : MonoBehaviour
{
  
    [SerializeField] float missileSpeed = 1f;
    [SerializeField] float SpeedMultiplier = 100f;
    [SerializeField] float MaxmissileSpeed = 11000f;
    [SerializeField] float decSpeed = 5f;
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] GameObject Missile;

    //CachedReferences (if any)
    Rigidbody rb;
    // public Animator anim;
    //States

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (missileSpeed < MaxmissileSpeed)
        {
            missileSpeed += SpeedMultiplier * Time.deltaTime;
        }

        Moving();
    }

    void Moving()
    {
        //For the boat to keep moving Forward
        var mSpeed = missileSpeed * Time.fixedDeltaTime;
        var FallSpeed = decSpeed * Time.deltaTime;
        rb.velocity = transform.forward * mSpeed;
        //rb.MovePosition(Vector3.forward * mSpeed + (-transform.up * FallSpeed));
        if (transform.position.y <= -71.5f)
        {
            decSpeed = 0;
        }
        float horizontalInput = Input.GetAxisRaw("Horizontal") * missileSpeed * Time.deltaTime;
       // Vector3 movementDirection = new Vector3(horizontalInput, 0, 0);
        transform.Translate(horizontalInput, 0, 0);

        //Saving a variable Vector3 Movement to use those axis values for rotation on click
        //if (movementDirection != Vector3.zero)
        //if (transform.rotation.y < 30 /*|| transform.rotation.y > -30*/)
        //{
          


        //   // Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
        //    //Mathf.Clamp(toRotation.y, -30, 30);
        //    //Debug.Log(toRotation.y);
        //    //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);


        //}
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -50, 50), transform.position.y, transform.position.z);
        //if (transform.localPosition.x >= 50f || transform.localPosition.x <= -50f)
        //{

        //    //transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        //  //  rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.Euler(0, 0, 0), 3 * Time.deltaTime);
        //    // Destroy(gameObject);
        //}


    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        //Destroy(gameObject, 0.5f);
        Missile.SetActive(false);

        if (collision.gameObject.tag == "Enemy")
        {
            //Destroy(gameObject,0.35f);
            Missile.SetActive(false);
        }
    }
}

