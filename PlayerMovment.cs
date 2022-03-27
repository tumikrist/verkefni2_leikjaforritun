using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class PlayerMovment : MonoBehaviour
{
    // bara búa til values

    public float speed = 20;
    public float sideways = 20;
    public float jump = 20;
    //private Rigidbody leikmadur;
    public static int count;
    public Text countText;

    public float thrust_up;

    public Rigidbody rb;

    bool touch_ground = true;

    void Start()
    {
        Debug.Log("byrja");
        // kallar á count text fallið
        SetCountText();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //sný player
        if (Input.GetKey("f"))
        {
            transform.Rotate(new Vector3(0, 5, 0));
        }
        if (Input.GetKey("g"))//snúa leikmanni
        {
            transform.Rotate(new Vector3(0, -5, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space))//hoppa
        {
            /* Debug.Log("hopp");
            Debug.Log(touch_ground); */
            
            // til að hoppa bara 1 sinni 
            if(touch_ground == true){
                rb.AddForce(Vector3.up * thrust_up , ForceMode.Impulse);
                touch_ground = false;
            } 
        }

        if (transform.position.y <= -1)
        {
            Endurræsa();
        }
        if (Input.GetKey(KeyCode.UpArrow))//áfram
        {
            transform.position += transform.forward * speed ;
        }
        if (Input.GetKey(KeyCode.DownArrow))// til baka
        {
            transform.position += -transform.forward * speed;

        }
        if (Input.GetKey(KeyCode.RightArrow))//hægri
        {
            transform.position += transform.right * sideways;
        }
        if (Input.GetKey(KeyCode.LeftArrow))//vinstri
        {
            //hreyfir player um sideways í hvert skipti sem ýtt er á leftArrow
            transform.position += -transform.right * sideways;
        }
        /* if (Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("búmm");
            //Vector3 movement = new Vector3(0, 10, 0);
            transform.position +=transform.up *jump;
        } */
        if (transform.position.y<=-1)
        {
            // ef player dettur undir levelið
            Endurræsa();
        }
    }
   
     void OnCollisionEnter(Collision collision)
    {
        // ef player keyrir á object sem heitir hlutur
        if (collision.collider.tag == "money")
        {
            Debug.Log("hitti money");
            collision.collider.gameObject.SetActive(false);
            count = count + 1;
            // Debug.Log("Nú er ég komin með " + count);
            SetCountText();//kallar á fallið
        }
        if (collision.collider.tag == "pikk")
        {
            collision.collider.gameObject.SetActive(false);
            count = count + 5;
            //Debug.Log("Nú er ég komin með " + count);
            SetCountText();//kallar á fallið
        }
        if (collision.collider.tag == "collide_object")
        {
            count = 0;
            //collision.collider.gameObject.SetActive(false);
            StartCoroutine(Bida());
            //count = count -3;
            //Debug.Log("Nú er ég komin með " + count);
            SetCountText();//kallar á fallið
        }
        if (collision.collider.tag == "ground") {
            // fyrir að hoppa 1 sinni
            touch_ground = true;
        }
    }
    void SetCountText()
    {
        // fyrir stig
        countText.text = "Stig: " + count.ToString();
       
        /* if (count <= 0)
        {
            this.enabled = false;//kemur í veg fyrir að playerinn geti hreyfst áfram eftir dauðan
            countText.text = "Svo dauðððððððððððððððður " + count.ToString()+" stigum";

            StartCoroutine(Bida());
            
        } */
        
    }
    IEnumerator Bida()
    {   
        // endur ræsa level
        yield return new WaitForSeconds(1);
        Endurræsa();
    }
   
    public void Byrja()
    {
        SceneManager.LoadScene(1);
    }
    public void Endurræsa()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Level_1
        SceneManager.LoadScene(0);
    }

}
