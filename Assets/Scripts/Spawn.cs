using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public bool inPlay;
    public GameObject spike;
    public List<GameObject> Cars;
    public List<float> lane_coordinate;
    public GameObject Tile;
    public List<GameObject> Tiles;
    public float probSpawnCar;//out of 100
    public float probSpawnCollectible;//out of 100
    public float probSpike;//out of 100
    float sense, spawn;
    public float timeDiff, timeDiffC, timeDiffS;
    float timePassed = 0f; 
    float timePassedC = 0f; 
    float timePassedS = 0f; 
    System.Random rnd;
    public GameObject Collectible;
    int z = 0;
    float x;
    void Start()
    {
        inPlay = true;
        float x1 = Tiles[0].transform.position.y;
        float x2 = Tiles[1].transform.position.y;
        sense = (x1 + x2) / 2;
        spawn = (x2-x1);
        rnd = new System.Random();
        z = 0;
    }

    // Update is called once per frame
    void Update()
    {
    if(inPlay){
        Tiles.RemoveAll(item => item == null);
        timePassed += Time.deltaTime;
        int y = rnd.Next(0, 100);
        if(y<probSpawnCar && timePassed >= timeDiff){
            timePassed = 0;
            float x = lane_coordinate[rnd.Next(0, lane_coordinate.Count)];
            float speed = 8 * (1 + rnd.Next(-3,4)/4);
            GameObject car = Instantiate(Cars[rnd.Next(0, Cars.Count)], new Vector3(x, spawn+sense, 0), Quaternion.identity, transform);
            car.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
        }
        y = rnd.Next(0, 100);
        timePassedC += Time.deltaTime;
        if((y<probSpawnCollectible  || z >= 0) && timePassedC >= timeDiffC){
            timePassedC = 0;
            if(z==0){
                z = rnd.Next(1,5);
                x = lane_coordinate[rnd.Next(0, lane_coordinate.Count)];
            }
            else{z--;}
            Instantiate(Collectible, new Vector3(x, spawn+sense, 0), Quaternion.identity, transform);
        }
        
        y = rnd.Next(0, 100);
        timePassedS += Time.deltaTime;
        if(y<probSpike && timeDiffS < timePassedS){
            timePassedS = 0;
            if(rnd.Next(0, 100)<50){
                Instantiate(spike,new Vector3(-1.71f,spawn+sense, 0), Quaternion.identity, transform);
            }
            else{
                Quaternion Rotation = Quaternion.identity;
                Rotation.eulerAngles = new Vector3(0, 0, 180);
                Instantiate(spike, new Vector3(1.71f,spawn+sense, 0), Rotation, transform);
            }
        }

        int index = Tiles.Count - 1;
        if(Tiles[index].transform.position.y <= sense){
            GameObject NewTile = Instantiate(Tile,new Vector3(Tiles[index].transform.position.x, Tiles[index].transform.position.y + spawn, Tiles[index].transform.position.z) , Quaternion.identity, transform);
            Tiles.Add(NewTile);
        }
    }
    else{
        for(int i=0; i<transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            child.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            if(child.CompareTag("Collectible") || child.CompareTag("Car")){
                //
            }
            else{
                for(int j=0; j<child.transform.childCount; j++)
                {
                    child.transform.GetChild(j).gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
                }
            }
        }
    }
    }
}
