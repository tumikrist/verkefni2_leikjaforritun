using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skipti : MonoBehaviour
{
    void Start()
    {
        Debug.Log("byrja");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name=="player"){
            // ef maður deyr
            other.gameObject.SetActive(false);
            StartCoroutine(Bida());     
        }
    }
    IEnumerator Bida()
    {
        // bíða í 3 sec svo restarta leikinn
        yield return new WaitForSeconds(3);
        Endurræsa();
    }
    public void Endurræsa()
    {
        // loada næstu scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);//næsta sena
    }

}
