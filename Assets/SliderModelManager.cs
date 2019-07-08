﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderModelManager : MonoBehaviour
{
	
	public List<GameObject> objects;
	public List<GameObject> sockel;

    // Start is called before the first frame update
    void Start()
    {
        objects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }	

	public void addToObjects(GameObject obj){
		int lastObjIndex = objects.Count; 
		if(lastObjIndex<6){
			objects.Add(obj);
			Debug.Log("Array ok");
			addToBoundingBox(obj,lastObjIndex);
		}else{
			Debug.Log("Array Full");
		}
	}

	public void addToBoundingBox(GameObject obj,int sockel_Index){
        GameObject boundingBox = sockel[sockel_Index].transform.GetChild(0).gameObject;
        Transform sockel_Transform = sockel[sockel_Index].transform;
        obj.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        obj.transform.SetParent(boundingBox.transform, false);
        /*obj.transform.parent = boundingBox.transform;
        obj.transform.position = boundingBox.transform.position;*/
        obj.transform.position -= new Vector3(0f, 0.03f, 0f);
        boundingBox.GetComponent<rescaleOBJ>().containedOBJ = obj;
 
	}

	 //grandChild = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
}
