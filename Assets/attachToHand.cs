using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class attachToHand : MonoBehaviour
{
    public GameObject _HandController;
    private HandModel _HandModel;
    private LeapServiceProvider LSP;
    // Start is called before the first frame update
    void Start()
    {
        LSP = FindObjectOfType<LeapServiceProvider>() as LeapServiceProvider;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("HANDS: " + LSP.CurrentFrame.Hands);
        if (gameObject.GetComponent<MenuActions>().isActive && LSP.CurrentFrame.Hands.Count > 1)
        {
            GameObject HandObject = _HandController.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
            transform.position = HandObject.transform.position + new Vector3(0.1f, 0.1f, 0);
        }
    }
}
