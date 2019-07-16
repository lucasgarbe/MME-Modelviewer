using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Aktionen die der Drehteller ausführen kann
 */
public class TurntableActions : MonoBehaviour
{
    private float Rotation = 0; /**< Grad der Rotation */

    /** Führt die Rotation aus */
    void Update()
    {
        transform.Rotate(0, Rotation, 0);
    }

    /** Fügt eine Links-Rotation hinzu */
    public void AddLeftRotation()
    {
        Rotation = 10;
    }

    /** Fügt eine Rechts-Rotation hinzu */
    public void AddRightRotation()
    {
        Debug.Log("AddRightRotation");
        Rotation = -10;
    }

    /** Setzt die Rotation zurück */
    public void RemoveRotation()
    {
        Rotation = 0;
    }
}
