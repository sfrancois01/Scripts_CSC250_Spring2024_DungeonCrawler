using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class PlayerX : MonoBehaviour
{
    public GameObject Portal;
    private float speed = 3.0f;
   
    void Start()
    {
        
    }

   /* private void OnCollisionEnter(Collision collision) 
   {
       print("onCollision");
   }*/

   private void OnTriggerEnter(Collider Portal)
   {
       //print("Secret Number = " + MySingleton.secretNumber);
       //MySingleton.secretNumber = 5;
       EditorSceneManager.LoadScene("Scene2");

   }

    

    // Update is called once per frame
    private void Update()
    {
        
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.Portal.transform.position, this.speed * Time.deltaTime);
       
    }
}
