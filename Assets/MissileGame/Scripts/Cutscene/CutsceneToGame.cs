using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneToGame : MonoBehaviour
{
    public GameObject missile;
    public GameObject cam;
   public GameObject Flight;
    public GameObject flightcam;
    public GameObject miss;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Game", 3.65f);
        Invoke("game2", 6.2f);
        Destroy(this,6.2f);

    }
    void Game()
    {
        missile.SetActive(true);
        cam.SetActive(true);
        flightcam.SetActive(false);
        miss.SetActive(false);
    }

    void game2()
    {
        Flight.SetActive(false);
      
    }
}
