using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
{
    public GameObject Instruction;
    // Start is called before the first frame update
    void Start(){
        Instruction.SetActive(false);
    }
    public void NextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Instructions(){
        Instruction.SetActive(true);
    }

    public void Back(){
        Instruction.SetActive(false);
    }
}
