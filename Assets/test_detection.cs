using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_detection : MonoBehaviour
{
    public void rotate()
    {
        transform.Rotate(0, 10 * Time.deltaTime, 0, Space.World);
    }
}
