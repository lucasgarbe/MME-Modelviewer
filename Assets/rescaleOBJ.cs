using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Skaliert das geladen Model auf die Größe der gegebenen Bounding Box
 */
public class rescaleOBJ : MonoBehaviour
{
	public GameObject boundingBox; /**< ausgewählte Bounding Box */
	public GameObject containedOBJ; /**< Model, welches skaliert wird */ 

    /** Checkt bei jedem Durchgang alle 6 BoxCollider der Bounding Box,
     * wenn das geladene Model sich mit einem der 6 BoxCollider überschneidet
     * wird es herunterskaliert.
     */
    void Update()
    {
		Collider[] colliderBoundingBox = boundingBox.GetComponentsInChildren<Collider>();
		Collider colliderContainedOBJ = containedOBJ.GetComponent<Collider>();

		foreach(Collider collider in colliderBoundingBox){
            if (collider != colliderContainedOBJ)
            {
                bool doesIntersect = collider.bounds.Intersects(colliderContainedOBJ.bounds);
                Debug.Log("Intersects" + doesIntersect);
                if (doesIntersect)
                {
                    Debug.Log("IntersectCollider" + collider);
                    if (containedOBJ.transform.localScale.x > 0 && containedOBJ.transform.localScale.y > 0 && containedOBJ.transform.localScale.z > 0)
                    {
                        containedOBJ.transform.localScale -= new Vector3(0.001f, 0.001f, 0.001f);
                        Debug.Log(collider.bounds.ToString());
                        doesIntersect = false;
                    }
                    break;
                }
                Debug.Log("ende intersect");
            }
		}
	
			
    }


}
