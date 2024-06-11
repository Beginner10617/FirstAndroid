using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    int score = 0;
    public TMP_Text Score;
    public GameObject End;
    public GameObject BG;
    // Start is called before the first frame update
    void Start()
    {
        End.SetActive(false);
        Score.text = "SCORE : "+score.ToString();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Collectible")){
            Destroy(other.gameObject);
            score += 1;
        }
        if(other.gameObject.CompareTag("Car")){
            Debug.Log(other.gameObject);
            Debug.Log("Collided, Game Over");
            End.SetActive(true);
            BG.GetComponent<Spawn>().inPlay = false;
        }
    }
    void Update()
    {
        Score.text = "SCORE : "+score.ToString();  
           
    }
}
