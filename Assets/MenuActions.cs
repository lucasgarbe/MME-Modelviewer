using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActions : MonoBehaviour
{
    void Start()
    {
        HideMenu();
    }

    public void HideMenu()
    {
        Transform[] transforms = gameObject.GetComponentsInChildren<Transform>();
        
        foreach(Transform child in transforms)
        {
            GameObject childObject = child.gameObject;
            Debug.Log("ChildObject "+ childObject);
            Renderer childRenderer = childObject.GetComponent<Renderer>();
            GameObject childObjectButton = childObject.transform.GetChild(0).gameObject;
            Debug.Log("ChildObjectButton " + childObjectButton);
            Renderer childObjectButtonRenderer = childObjectButton.GetComponent<Renderer>();
            GameObject childObjectButtonInner = childObjectButton.transform.GetChild(0).gameObject;
            Debug.Log("ChildObjectButtonInner " + childObjectButtonInner);
            Renderer childObjectButtonInnerRenderer = childObjectButtonInner.GetComponent<Renderer>();

            childRenderer.enabled = false;
            childObjectButtonRenderer.enabled = false;
            childObjectButtonInnerRenderer.enabled = false;
        }
    }

    public void ShowMenu()
    {
        Debug.Log("In Show beginning!!!");
        Transform[] transforms = gameObject.GetComponentsInChildren<Transform>();

        foreach (Transform child in transforms)
        {
            GameObject childObject = child.gameObject;
            Renderer childRenderer = childObject.GetComponent<Renderer>();
            GameObject childObjectButton = childObject.transform.GetChild(0).gameObject;
            Renderer childObjectButtonRenderer = childObjectButton.GetComponent<Renderer>();
            GameObject childObjectButtonInner = childObjectButton.transform.GetChild(0).gameObject;
            Renderer childObjectButtonInnerRenderer = childObjectButtonInner.GetComponent<Renderer>();

            childRenderer.enabled = true;
            childObjectButtonRenderer.enabled = false;
            childObjectButtonInnerRenderer.enabled = false;
        }

        Debug.Log("In Show!!!");
    }
}
