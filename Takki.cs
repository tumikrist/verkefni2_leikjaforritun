using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Takki : MonoBehaviour
{
    public void Byrja()
    {
        // byrjar scene 1
        SceneManager.LoadScene(1);
    }
    public void Endir()
    {
        // loadar scene 0 
        SceneManager.LoadScene(0);
        PlayerMovment.count = 0;
    }
    
}
