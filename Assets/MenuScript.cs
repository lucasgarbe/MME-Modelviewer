using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Crosstales.FB;
using Dummiesman;
using System.IO;
using Leap.Unity.Interaction;


public class MenuScript : MonoBehaviour
{		
		public Canvas menu;
		string objPath = string.Empty;
		string error = string.Empty;
		GameObject loadedObject;

	public void continueScene(){
		menu.enabled = false;
		Debug.Log(menu.enabled);
	}

	public void loadFile(){
		string objPath = FileBrowser.OpenSingleFile("obj");
		if (loadedObject != null) Destroy(loadedObject);
        loadedObject = new OBJLoader().Load(objPath);
        loadedObject.transform.position = new Vector3(-0.3f, 4.4f, -14.8f);
        loadedObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        Rigidbody rigid = loadedObject.AddComponent<Rigidbody>();
        rigid.useGravity = false;
        BoxCollider body = loadedObject.AddComponent<BoxCollider>();
		loadedObject.AddComponent<InteractionBehaviour>();
	}

	public void exitApplication(){
		Debug.Log("Exit");
		Application.Quit();
	}
}