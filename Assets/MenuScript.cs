using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Crosstales.FB;
using Dummiesman;
using System.IO;
using Leap.Unity.Interaction;


public class MenuScript : MonoBehaviour
{		
		public GameObject boundingBox;
		public Canvas menu;
		string objPath = string.Empty;
		string error = string.Empty;
		GameObject loadedObject;


	void Start(){
		
	}

	public void continueScene(){
		menu.enabled = false;
		Debug.Log(menu.enabled);
	}

	public void loadFile(){
		GameObject slider = GameObject.Find("Slider");

		string objPath = FileBrowser.OpenSingleFile("obj");
		if (loadedObject != null) Destroy(loadedObject);
        loadedObject = new OBJLoader().Load(objPath);

		loadedObject.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
		Rigidbody rigid = loadedObject.AddComponent<Rigidbody>();
        rigid.useGravity = false;
        rigid.isKinematic = true;
        BoxCollider body = loadedObject.AddComponent<BoxCollider>();
		loadedObject.AddComponent<InteractionBehaviour>();

		GameObject.Find("ModelSelectSlider").GetComponent<SliderModelManager>().addToObjects(loadedObject);

		//loadedObject.transform.position = new Vector3(-0.329f,4.06f,-14.475f);
	}

	public void exitApplication(){
		Debug.Log("Exit");
		Application.Quit();
	}

}