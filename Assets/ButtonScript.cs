using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Detected");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered");
    }
}
