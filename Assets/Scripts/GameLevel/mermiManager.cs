using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermiManager : MonoBehaviour
{
    float mermiHizi = 15f;
   
   /* void Start()
    {
      if(this.gameObject != null)
        {
            Destroy(this.gameObject,2f);
        }  
    }*/

    
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime*mermiHizi);
    }
}
