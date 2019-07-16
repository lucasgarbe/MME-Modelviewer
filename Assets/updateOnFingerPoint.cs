using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using Leap.Unity.Interaction;


/** Funktionen die ausgeführt, wenn ein Fingezeig erkannt wurde.
 */
public class updateOnFingerPoint : MonoBehaviour
{
    public bool placedOnTurntable = false; /**< true, falls Objekt momentan auf dem Drehteller platziert ist*/

    /** Klont das Objekt auf den Drehteller */
    public void Clone()
    {
        Debug.Log("CLONE");
        GameObject obj = transform.GetChild(6).gameObject;
        GameObject podest = GameObject.Find("Podest");

        if (!placedOnTurntable)
        {
            Transform spawn = podest.transform;
            GameObject clone = Instantiate(obj, spawn);
            clone.transform.position += new Vector3(0f, 0.355f, 0f);
            clone.AddComponent<InteractionBehaviour>();
            clone.AddComponent<resetPosition>();
            podest.transform.GetChild(1).GetComponent<rescaleOBJTurntable>().containedOBJs.Add(clone);
            placedOnTurntable = true;
        }
    } 

}
