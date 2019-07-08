using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class DetectMovement : MonoBehaviour
{
    LeapServiceProvider provider;
    private int LHPalmDirection;
    private int RHPalmDirection;
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
            if (hand.IsLeft)
            {
                Leap.Vector velo = hand.PalmVelocity;

                if (velo.x > 0.2 && LHPalmDirection == 1)
                {
                    Debug.Log("ROTATE RIGHT");
                    TurntableScript.AddRightRotation();
                }
                if ((velo.x > - 0.2 || velo.x < 0.2) && LHPalmDirection == 1)
                {
                    TurntableScript.RemoveRotation();
                }
                if (velo.x < -0.2 && LHPalmDirection == 1)
                {
                    TurntableScript.AddLeftRotation();
                }
            }
            else
            {

            }
        }
    }

    public void SetLHPalmLeft()
    {
        LHPalmDirection = -1;
        Debug.Log("lh palm left");
    }

    public void SetLHPalmNone()
    {
        LHPalmDirection = 0;
        Debug.Log("lh palm none");
    }

    public void SetLHPalmRight()
    {
        LHPalmDirection = 1;
        Debug.Log("lh palm right");
    }

    public void SetRHPalmLeft()
    {
        RHPalmDirection = -1;
    }

    public void SetRHPalmNone()
    {
        RHPalmDirection = 0;
    }

    public void SetRHPalmRight()
    {
        RHPalmDirection = 1;
    }
}
