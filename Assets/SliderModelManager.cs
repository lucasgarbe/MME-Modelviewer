using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Managed die Objekte auf dem Model Slider
 */
public class SliderModelManager : MonoBehaviour
{
	
	public List<GameObject> objects; /**< Liste der Objekte die auf dem Model Slider platziert sind */
	public List<GameObject> sockel; /**< List der Sockel, auf denen die Objekte platziert werden */

    /** Initiiert leere Liste für objects
     */
    void Start()
    {
        objects = new List<GameObject>();
    }

    /** Objekt wird in die Liste objects geschrieben und auf dem Model Slider platziert
     * @param obj zu platzierendes Objekt
     */
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

    /** Das Objekt wird an die Bounding Box gehängt.
     * @param obj zu platzierendes Objekt
     * @param sockel_Index Index des Sockels, auf dem das Objekt platziert werden soll
     */
	public void addToBoundingBox(GameObject obj,int sockel_Index){
        GameObject boundingBox = sockel[sockel_Index].transform.GetChild(0).gameObject;
        Transform sockel_Transform = sockel[sockel_Index].transform;
        obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        obj.transform.SetParent(boundingBox.transform, false);
        /*obj.transform.parent = boundingBox.transform;
        obj.transform.position = boundingBox.transform.position;*/
        obj.transform.position += new Vector3(0f, -0.02f, 0f);
        boundingBox.GetComponent<rescaleOBJ>().containedOBJ = obj;
 
	} 

}
