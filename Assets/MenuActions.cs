using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActions : MonoBehaviour
{
    public bool isActive;
    public Camera cam;

    void Start()
    {
        HideMenu();
    }

    public void HideMenu()
    {
        transform.position = new Vector3(-10, -10, -10);
        isActive = false;
    }

    public void ShowMenu()
    {
        isActive = true;
    }

    public void BackgroundColorBlue()
    {
        cam.backgroundColor = new Color(0.1f, 0.001f, 0.4f, 1f);
    }

    public void BackgroundColorGrey()
    {
        cam.backgroundColor = new Color(0.3f, 0.3f, 0.3f, 0f);
    }

    public void BackgroundColorGreen()
    {
        cam.backgroundColor = new Color(0.1f, 0.4f, 0.001f, 1f);
    }
}
