using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lokastig : MonoBehaviour
{
    public Text stig;
    // Start is called before the first frame update
    void Start()
    {
        // fyrir lokascene til að fá stig
        stig.text = "Stig: " + PlayerMovment.count.ToString();
    }

    
}
