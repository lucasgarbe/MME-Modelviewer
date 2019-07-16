using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Skaliert Objekte auf dem Drehteller passend zur Bounding Box des Drehtellers
 */
public class rescaleOBJTurntable : MonoBehaviour
{
    public GameObject boundingBox; /**< Bounding Box des Drehtellers */
    public List<GameObject> containedOBJs; /**< Liste aller Objekten, die auf dem Drehteller platziert sind */

    /** Neue leere Liste wird erstellt */
    void Start()
    {
        containedOBJs = new List<GameObject>();
    }

    /** Für alle Objekte auf dem Drehteller,
     * wird überprüft ob sie sich mit der Bounding Box des Drehteller schneiden,
     * falls sie sich schneiden werden sie herunterskaliert
     */
    void Update()
    {
        foreach (GameObject coOBJ in containedOBJs)
        {
            Collider[] colliderBoundingBox = boundingBox.GetComponentsInChildren<Collider>();
            Collider colliderContainedOBJ = coOBJ.GetComponent<Collider>();
            bool isScaled = coOBJ.GetComponent<resetPosition>().isScaled;
            bool intersected = false;
            foreach (Collider collider in colliderBoundingBox)
            {
                if (collider != colliderContainedOBJ || isScaled)
                {
                    bool doesIntersect = collider.bounds.Intersects(colliderContainedOBJ.bounds);
                    Debug.Log("Intersects" + doesIntersect);
                    if (doesIntersect)
                    {
                        Debug.Log("IntersectCollider" + collider);
                        if (coOBJ.transform.localScale.x > 0 && coOBJ.transform.localScale.y > 0 && coOBJ.transform.localScale.z > 0)
                        {
                            coOBJ.transform.localScale -= new Vector3(0.001f, 0.001f, 0.001f);
                            Debug.Log(collider.bounds.ToString());
                            doesIntersect = false;
                            intersected = true;
                        }
                        break;
                    }
                    Debug.Log("ende intersect");
                }
            }
            if (!intersected)
            {
                isScaled = true;
            }
        }
    }
}
