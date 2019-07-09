using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;


public class updateOnFingerPoint : MonoBehaviour
{

    FingerDirectionDetector FDD;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FDD.IsActive)
        {
            Instantiate(gameObject, GameObject.Find("Podest").transform);

        }
    }
}
