using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class LeapMotionSkript : MonoBehaviour
{
    LeapServiceProvider provider;
    // Start is called before the first frame update
    void Start()
    {
        provider = FindObjectOfType<LeapServiceProvider>() as LeapServiceProvider;
    }

    // Update is called once per frame
    void Update()
    {
        Frame frame = provider.CurrentFrame;
        foreach(Hand hand in frame.Hands)
        {
            if(hand.IsLeft)
            {
                Debug.Log("Moin funktioniert");
            }
        }
    }
}
