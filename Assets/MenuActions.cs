using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActions : MonoBehaviour
{
    public bool isActive;
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
}
