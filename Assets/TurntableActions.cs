using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurntableActions : MonoBehaviour
{
    private float Rotation = 0;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Rotation, 0);
    }

    public void AddLeftRotation()
    {
        Rotation = 10;
    }

    public void AddRightRotation()
    {
        Debug.Log("AddRightRotation");
        Rotation = -10;
    }

    public void RemoveRotation()
    {
        Rotation = 0;
    }
}
