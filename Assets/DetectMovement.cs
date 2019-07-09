using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class DetectMovement : MonoBehaviour
{
    LeapServiceProvider provider;
    private string LHPalmDirection;
    private string RHPalmDirection;
    TurntableActions TurntableScript;

    void Start()
    {
        provider = FindObjectOfType<LeapServiceProvider>() as LeapServiceProvider;
        TurntableScript = GameObject.Find("Podest").GetComponent<TurntableActions>();
    }

    // Update is called once per frame
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

    public void SetLHPalmLeft()
    {
        LHPalmDirection = "left";
        Debug.Log("lh palm left");
    }

    public void SetLHPalmRight()
    {
        LHPalmDirection = "right";
        Debug.Log("lh palm right");
    }

    public void SetLHPalmDown()
    {
        LHPalmDirection = "down";
        Debug.Log("lh palm down");
    }

    public void SetLHPalmUp()
    {
        LHPalmDirection = "up";
        Debug.Log("lh palm up");
    }

    public void SetLHPalmNone()
    {
        LHPalmDirection = "none";
        Debug.Log("lh palm none");
    }






    public void SetRHPalmLeft()
    {
        RHPalmDirection = "left";
        Debug.Log("rh palm left");
    }

    public void SetRHPalmRight()
    {
        RHPalmDirection = "right";
        Debug.Log("rh palm right");
    }

    public void SetRHPalmDown()
    {
        RHPalmDirection = "down";
        Debug.Log("rh palm down");
    }

    public void SetRHPalmUp()
    {
        RHPalmDirection = "up";
        Debug.Log("rh palm up");
    }

    public void SetRHPalmNone()
    {
        RHPalmDirection = "none";
        Debug.Log("rh palm none");
    }

}
