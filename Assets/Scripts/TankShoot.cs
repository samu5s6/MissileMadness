using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bullet2;
    public GameObject bullet3;
    public Transform Shootpoint; public Transform Shootpoint2; public Transform Shootpoint3;
    public float speed=1000f; 
    public float upspeed=500f;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("shoot", true);
            shoot1();
            Invoke("sh", 0.5f);
            Invoke("shoot2", 1f);
            Invoke("shoot2", 1f);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("shoot", true);
            shoot1();
           // Invoke("sh", 1.5f);
            Invoke("shoot2", 1f);
            Invoke("shoot3", 1f);


        }

    }

    void shoot1()
    {
        GameObject EnemyBullet = Instantiate(bullet, Shootpoint.transform.position, transform.rotation);
      // EnemyBullet.GetComponent<Rigidbody>().velocity = speed * -transform.forward * Time.deltaTime + upspeed * transform.up * Time.deltaTime;
       // Destroy(EnemyBullet.gameObject, 0.5f);
       
        //Invoke("shoot2", 1f);
    }    
    void sh()
    {
        GameObject EnemyBullet2 = Instantiate(bullet, Shootpoint.transform.position, transform.rotation);
      //  EnemyBullet2.GetComponent<Rigidbody>().velocity = speed * -transform.forward * Time.deltaTime + speed * transform.up * Time.deltaTime;
    }
   void shoot2()
    {
        GameObject EnemyBullet2 = Instantiate(bullet2, Shootpoint2.transform.position, transform.rotation);
       // EnemyBullet2.GetComponent<Rigidbody>().velocity = speed * -transform.forward * Time.deltaTime + speed * transform.up * Time.deltaTime;
       // Invoke("shoot3", 1f);
    }
    void shoot3()
    {
        GameObject EnemyBullet3 = Instantiate(bullet3, Shootpoint3.transform.position, transform.rotation);
        EnemyBullet3.GetComponent<Rigidbody>().velocity = speed * -transform.forward * Time.deltaTime + speed * transform.up * Time.deltaTime;
    }

}
