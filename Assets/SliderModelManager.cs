using System.Collections;
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
		sockel[sockel_Index].transform.GetChild(0).gameObject.GetComponent<rescaleOBJ>().containedOBJ = obj;
		GameObject cO = sockel[sockel_Index].transform.GetChild(0).gameObject.GetComponent<rescaleOBJ>().containedOBJ;
		Debug.Log(cO+"OBJ-Before"); 
		Debug.Log(cO+"OBJ-After");
		Transform sockel_Transform = sockel[sockel_Index].transform;
		obj.transform.position = sockel_Transform.position + new Vector3(0f,0.018f,0f);
	}

	 //grandChild = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
}
