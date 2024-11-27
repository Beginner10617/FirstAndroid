using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody2D rb2;
    [SerializeField] Pause pause;
    public GameObject BG;
    public float scale;
    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(pause.isPaused) return;
        Vector2 Force = new Vector2(Input.acceleration.x * scale,0);
        rb2.velocity = Force;
        if(BG.GetComponent<Spawn>().inPlay == false){
            rb2.velocity = new Vector2(0,0);
            Destroy(this);
        } 
    }
}
