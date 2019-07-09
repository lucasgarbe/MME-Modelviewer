using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Crosstales.FB;
using Dummiesman;
using System.IO;
using Leap;
using Leap.Unity;
using Leap.Unity.Interaction;


public class MenuScript : MonoBehaviour
{		
	public GameObject boundingBox;
	public Canvas menu;
	string objPath = string.Empty;
	string error = string.Empty;
	GameObject loadedObject;
    FingerDirectionDetector FingerDetector;
    public HandModel Hand;
    private UnityAction FireAction;

	void Start(){
		
	}

	public void continueScene(){
		menu.enabled = false;
		Debug.Log(menu.enabled);
	}

	public void loadFile(){
		GameObject slider = GameObject.Find("Slider");

		string objPath = FileBrowser.OpenSingleFile("obj");
		//if (loadedObject != null) Destroy(loadedObject);
        loadedObject = new OBJLoader().Load(objPath);
        //loadedObject.transform.localScale = new Vector3(0.002f, 0.002f, 0.002f);
        Bounds b = RecursiveMeshBB(loadedObject);
        
        Rigidbody rigid = loadedObject.AddComponent<Rigidbody>();
        rigid.useGravity = false;
        rigid.isKinematic = true;
        BoxCollider body = loadedObject.AddComponent<BoxCollider>();
        body.center = b.center;
        body.size = b.size;
		loadedObject.AddComponent<InteractionBehaviour>();

        FingerDirectionDetector originalFDD = gameObject.GetComponent<FingerDirectionDetector>();
        CopyComponent(originalFDD, loadedObject);
        FingerDetector = loadedObject.GetComponent<FingerDirectionDetector>();
        FingerDetector.TargetObject = loadedObject.transform;
        

        loadedObject.AddComponent<updateOnFingerPoint>();

		GameObject.Find("ModelSelectSlider").GetComponent<SliderModelManager>().addToObjects(loadedObject);

		//loadedObject.transform.position = new Vector3(-0.329f,4.06f,-14.475f);
	}

	public void exitApplication(){
		Debug.Log("Exit");
		Application.Quit();
	}

    private Bounds RecursiveMeshBB(GameObject g)
    {
        MeshRenderer[] mr = g.GetComponentsInChildren<MeshRenderer>();
        if (mr.Length > 0)
        {
            Bounds b = mr[0].bounds;
            for(int i=1; i<mr.Length; i++)
            {
                b.Encapsulate(mr[i].bounds);
            }
            return b;
        }
        else
        {
            return new Bounds();
        }
    }

    public void Clone()
    {
        Instantiate(loadedObject, GameObject.Find("Podest").transform);
        
    }

    IEnumerator test()
    {
        yield return new WaitForSecondsRealtime(3);
    }

    T CopyComponent<T>(T original, GameObject destination) where T : Component
    {
        System.Type type = original.GetType();
        Component copy = destination.AddComponent(type);
        System.Reflection.FieldInfo[] fields = type.GetFields();
        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(copy, field.GetValue(original));
        }
        return copy as T;
    }
}