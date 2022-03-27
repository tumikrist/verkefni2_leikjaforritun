using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endurbyrja : MonoBehaviour
{
    // Start is called before the first frame update

    // byrjar aftur
    public void Byrja()
    {
        SceneManager.LoadScene(1);
    }
}
