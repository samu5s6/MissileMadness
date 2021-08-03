using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    [SerializeField] private List<GameObject> tileList;

    private Queue<GameObject> tileQueue = new Queue<GameObject>();
    [SerializeField] private GameObject player;

    private float distance;
    [SerializeField] private float tileLength;



    //lg

    public GameObject enemy;
    public GameObject Prefab;
    public int numPoints = 9;




    void Start()
    {
        for (int i = 0; i < tileList.Count; i++)
        {

            if (i == 0)
            {
                SpawnTile(tileList[0]);

               
            }
            else
            {
                SpawnTile(tileList[i]);
            }

        }
    }



 

    // Update is called once per frame
    void Update()
    {
        if (distance > 500)
        {
            if (player.transform.position.z > distance - 400)
            {
                moveTile();
                moveTile();
            }
        }

    }

    private void SpawnTile(GameObject tile)
    {


    Vector3 p1 = transform.position;
    Vector3 p2 = enemy.transform.position;

    float step = 1f / (numPoints + 1);
    for (float lerpValue = step; lerpValue < 1f; lerpValue += step)
    {
        Vector3 v = Vector3.Lerp(p1, p2, lerpValue);

        //rotating the instantiated obj
        Vector3 direction = enemy.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        GameObject tileObject = Instantiate(tile, v, rotation);
            Debug.Log(tileObject.name);
        tileQueue.Enqueue(tileObject);
    }

        //GameObject tileObject = Instantiate(tile, transform.forward * distance, transform.rotation);
        
        //distance += tileLength;
    }

    private void moveTile()
    {
        GameObject tile = tileQueue.Dequeue();
        tile.transform.position = transform.forward * distance;
        distance += tileLength;
        tile.transform.rotation = transform.rotation;
        tileQueue.Enqueue(tile);
    }

}
