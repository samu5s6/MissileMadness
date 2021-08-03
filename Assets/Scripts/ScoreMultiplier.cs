using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMultiplier : MonoBehaviour
{
    [SerializeField] GameObject[] multiplierasset;
    levelling lev;

   // public int score = 0;
    [SerializeField] Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        lev = FindObjectOfType<levelling>();
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "Score :" + lev.score;
    }

  
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Invoke(nameof(eight), 2.5f);
        //switch (collision.gameObject.tag)
        //{
        //    case "x1":
        //        Debug.Log("Score:1");
        //        lev.score *= 2;
        //        Destroy(this,0.2f);
        //        break;
        //    case "x2":
        //        lev.score *= 2;
        //        Destroy(this, 0.2f);
        //        break;
        //    case "x4":
        //        lev.score *= 4;
        //        Debug.Log("Score:4");
        //        Destroy(this, 0.2f);
        //        break;
        //    case "x6":
        //        Debug.Log("Score:6");
        //        lev.score *= 6;
        //        Destroy(this, 0.2f);
        //        break;
        //    case "x8":
        //        lev.score *= 8;
        //        Debug.Log("Score:8");
        //        Destroy(this, 0.2f);
        //        break;
        //}
    }

    void eight()
    {
        lev.score *= 8;
    }
}
