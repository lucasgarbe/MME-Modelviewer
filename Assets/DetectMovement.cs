using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

/** Erkennt ob eine Bewegung der Hand vorliegt
 */
public class DetectMovement : MonoBehaviour
{
    private LeapServiceProvider provider; 
    private string LHPalmDirection; /**< speichert die Richtung der linken Handfläche */
    private string RHPalmDirection; /**< speichert die Richtung der rechten Handfläche */

    TurntableActions TurntableScript; /**< stellt das Skript zum Bewegen des Turntables bereit */

    /** LeapServiceProvider und TurntableScript werden gesetzt
     */
    void Start()
    {
        provider = FindObjectOfType<LeapServiceProvider>() as LeapServiceProvider;
        TurntableScript = GameObject.Find("Podest").GetComponent<TurntableActions>();
    }

    /** Für jeden Frame wird die Velocity der Hand abgegriffen
     * in Kombination mit der Richtung der Handflächen
     * werden dann die Methoden des Drehtellers aufgerufen
     */
    void Update()
    {
        Frame frame = provider.CurrentFrame;
        foreach (Hand hand in frame.Hands)
        {
            Leap.Vector velo = hand.PalmVelocity;

            if (hand.IsLeft)
            {

                if (LHPalmDirection == "right")
                {
                    if (velo.x < -0.2)
                    {
                        TurntableScript.AddLeftRotation();
                    }
                    else if (velo.x > 0.2)
                    {
                        TurntableScript.AddRightRotation();
                    }
                    else
                    {
                        TurntableScript.RemoveRotation();
                    }
                } else
                {
                    TurntableScript.RemoveRotation();
                }
            }
            else
            {
                if (RHPalmDirection == "left")
                {
                    if (velo.x < -0.2)
                    {
                        TurntableScript.AddLeftRotation();
                    }
                    else if (velo.x > 0.2)
                    {
                        TurntableScript.AddRightRotation();
                    }
                    else
                    {
                        TurntableScript.RemoveRotation();
                    }
                } else
                {
                    TurntableScript.RemoveRotation();
                }
            }
        }
    }

    /** Setzt die linke Handläche auf link */
    public void SetLHPalmLeft()
    {
        LHPalmDirection = "left";
        Debug.Log("lh palm left");
    }

    /** Setzt die linke Handläche auf rechts */
    public void SetLHPalmRight()
    {
        LHPalmDirection = "right";
        Debug.Log("lh palm right");
    }

    /** Setzt die linke Handläche auf unten */
    public void SetLHPalmDown()
    {
        LHPalmDirection = "down";
        Debug.Log("lh palm down");
    }

    /** Setzt die linke Handläche auf oben */
    public void SetLHPalmUp()
    {
        LHPalmDirection = "up";
        Debug.Log("lh palm up");
    }

    /** Setzt die linke Handläche auf none */
    public void SetLHPalmNone()
    {
        LHPalmDirection = "none";
        Debug.Log("lh palm none");
    }






    /** Setzt die rechte Handläche auf links */
    public void SetRHPalmLeft()
    {
        RHPalmDirection = "left";
        Debug.Log("rh palm left");
    }

    /** Setzt die rechte Handläche auf rechts */
    public void SetRHPalmRight()
    {
        RHPalmDirection = "right";
        Debug.Log("rh palm right");
    }

    /** Setzt die rechte Handläche auf unten */
    public void SetRHPalmDown()
    {
        RHPalmDirection = "down";
        Debug.Log("rh palm down");
    }

    /** Setzt die rechte Handläche auf oben */
    public void SetRHPalmUp()
    {
        RHPalmDirection = "up";
        Debug.Log("rh palm up");
    }

    /** Setzt die rechte Handläche auf none*/
    public void SetRHPalmNone()
    {
        RHPalmDirection = "none";
        Debug.Log("rh palm none");
    }

}
