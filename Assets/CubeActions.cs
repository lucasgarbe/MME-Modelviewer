using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeActions : MonoBehaviour
{
    public void rotate()
    {
        print("in rotate");
        transform.Rotate(0, 200, 0);
    }
}
