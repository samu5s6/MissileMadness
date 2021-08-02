using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MissileRLMove : MonoBehaviour
{
    
  
    public float sideSpeed = 5f;
    Rigidbody rb;
    [SerializeField] GameObject Missile;
     bool movingLeft, movingRight=false;  //TouchInput
    bool MoveLeft, MoveRight , MoveLeftUp, MoveRightUp;
    Animator anim;
    bool disableMove= false;
    bool disableL = false;

    Touch touch;
    public float speedModifier;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
   
      if(touch.deltaPosition.x >0)
        {
            anim.SetFloat("vertical", 1);
            anim.SetFloat("horizontal", 1f);
        }
       else  if (touch.deltaPosition.x < 0)
        {
            anim.SetFloat("vertical", 1);
            anim.SetFloat("horizontal", -1f);
        }
        else /*if (touch.deltaPosition.x == 0)*/
        {
            anim.SetFloat("vertical", 1);
            anim.SetFloat("horizontal", 0f);
        }

      
    }

    private void FixedUpdate()
    {

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6.3f, 6.3f), transform.position.y, transform.position.z);

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved )
            {
                if (touch.deltaPosition.x > 0)
                {
                    rb.AddForce(Vector3.right * speedModifier * speedModifier * Time.deltaTime, ForceMode.Force);
                }
                else if (touch.deltaPosition.x < 0)
                {
                    rb.AddForce(-Vector3.right * speedModifier * speedModifier * Time.deltaTime, ForceMode.Force/** sideSpeed * Time.fixedDeltaTime*/);
                }
                //move();            
            }

        }


    }

    void move()
    {
        transform.localPosition = new Vector3(transform.localPosition.x + touch.deltaPosition.x * speedModifier * Time.deltaTime * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
    }
    void left()
    {
        
       
    }
    void leftup()
    {
        rb.Sleep();
    }
    void right()
    {
        
        
    }
    void rightup()
    {
        rb.Sleep();
    }



    public void PtrDownButLEFT()
    {
        movingLeft = true;
    }
    public void PtrUpButLEFT()
    {
        movingLeft = false;
    }
    public void PtrDownButRIGHT()
    {
        movingRight = true;
    }
    public void PtrUpButRIGHT()
    {
        movingRight = false;
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
       // Debug.Log(collision.gameObject.name);
    }
}
