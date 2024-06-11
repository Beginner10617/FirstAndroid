using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        Destroy(Other.gameObject);
        Debug.Log("Destroyed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
