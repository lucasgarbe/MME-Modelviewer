using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Crosstales.FB;
using Dummiesman;
using System.IO;
using Leap.Unity.Interaction;

public class testzzz : MonoBehaviour
{

    string objPath = string.Empty;
    string error = string.Empty;
    GameObject loadedObject;

    // Start is called before the first frame update
    void Start()
    {
        this.OpenSingleFile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenSingleFile()
    {
        string objPath = FileBrowser.OpenSingleFile("obj");
        Debug.Log("Der da: "+objPath);

        if (loadedObject != null) Destroy(loadedObject);
        loadedObject = new OBJLoader().Load(objPath);
        loadedObject.transform.position = new Vector3(-0.29f, 4.06f, -14.6f);
        loadedObject.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        Rigidbody rigid = loadedObject.AddComponent<Rigidbody>();
        rigid.useGravity = false;
        BoxCollider body = loadedObject.AddComponent<BoxCollider>();
        //System.Type scriptType = System.Type.GetType("InteractionBehaviour");
        //Debug.Log(scriptType);
        //UnityScript s = loadedObject.AddComponent<>(scriptType);
        loadedObject.AddComponent<InteractionBehaviour>();
        //error = string.Empty;
    }

 
}
