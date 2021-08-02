using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMove : MonoBehaviour
{
    [SerializeField] float missileSpeed = 1f;
    [SerializeField] float rotationSpeed = 1f;

    public float storeVelo;
    //CachedReferences (if any)
    Rigidbody rb;

    //States

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Moving();
    }

    void Moving()
    {
        //For the boat to keep moving Forward
        var mSpeed = missileSpeed * Time.deltaTime;
        rb.velocity = transform.forward * mSpeed;

        float horizontalInput = Input.GetAxisRaw("Horizontal") * missileSpeed * Time.deltaTime;
        float verticalInput = Input.GetAxisRaw("Vertical") * missileSpeed * Time.deltaTime;

        Vector3 movementDirection = new Vector3(horizontalInput, -verticalInput, 0); //Saving a variable Vector3 Movement to use those axis values for rotation on click
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -40, 40), Mathf.Clamp(transform.position.y, -110, 20),transform.position.z);
        if(transform.localPosition.x >= 40f ||  transform.localPosition.x <= -40f)
        {
            transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
            // Destroy(gameObject);
        }
        if (transform.localPosition.y >= 20f || transform.localPosition.y <= -110f)
        {
            transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
            //  Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject,0.3f);
        }
    }
}
