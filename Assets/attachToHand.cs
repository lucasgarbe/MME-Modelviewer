using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attachToHand : MonoBehaviour
{
    public GameObject _HandController;
    private GameObject _HandModel;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<MenuActions>().isActive)
        {
            _HandModel = _HandController.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
            transform.position = _HandModel.transform.position + new Vector3(0.1f, 0.1f, 0);
            Debug.Log(_HandModel.transform.position + "Hand Position");
            Debug.Log(transform.position + "New Sphere Position");
        }
    }
}
