using System.Collections;
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
