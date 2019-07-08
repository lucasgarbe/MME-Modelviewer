﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rescaleOBJ : MonoBehaviour
{
	public GameObject boundingBox;
	public GameObject containedOBJ;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Collider[] colliderBoundingBox = boundingBox.GetComponentsInChildren<Collider>();
		Collider colliderContainedOBJ = containedOBJ.GetComponent<Collider>();

		foreach(Collider collider in colliderBoundingBox){
			bool doesIntersect = collider.bounds.Intersects(colliderContainedOBJ.bounds);
			if(doesIntersect){
				Debug.Log(doesIntersect+":intersect");
				containedOBJ.transform.localScale -= new Vector3(0.001f,0.001f,0.001f);
				break;
			}else{
				Debug.Log(collider+":nope");
			}
		}
	
			/*Debug.Log(colliderBoundingBox.bounds.ToString());
			
			colliderContainedOBJ.transform.localScale -= new Vector3(0.001f,0.001f,0.001f);
			doesIntersect = false;*/
    }


}