using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float rotateSpeed = 90f; 
    void Start()
    {
        
    }

    
    void Update()
    {
        
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }


}
