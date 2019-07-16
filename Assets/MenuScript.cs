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

/** Zuständig für das Laden der Dateien
 * und Funktionen der Buttons, die im Menü, welches über Escape aufgerufen wird,
 * angezeigt werden
 */
public class MenuScript : MonoBehaviour
{		
	public Canvas menu; /**< das Canvas, auf dem das Menü liegt */
	string objPath = string.Empty; /**< Pfad der obj-Datei */
	string error = string.Empty; /**< Fehler String, wird durch den OBJImporter erstellt */
	GameObject loadedObject; /**< referenziert das geladene Objekt */

    /** wird beim Drücken von Continue aufgerufen,
     * lässt Szene weiterlaufen
     */
	public void continueScene(){
		menu.enabled = false;
		Debug.Log(menu.enabled);
	}

    /** Lädt obj-Datei.
     * Datei wird mit FileBrowser ausgewählt
     * danach wird mit OBJImporter das Objekt geladen
     * 
     * Wird beim Drücke von Load OBJ ausgeführt
     */
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
        body.isTrigger = true;
        body.center = b.center;
        body.size = b.size;

		GameObject.Find("ModelSelectSlider").GetComponent<SliderModelManager>().addToObjects(loadedObject); 
	}

    /** Schließt das Programm wenn der Button Close aktiviert wird */
	public void exitApplication(){
		Debug.Log("Exit");
		Application.Quit();
	}

    /** Erstellt anhand der geladenen Meshes einen neuen Box-Collider, der alle Meshes umfasst */
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

    /** TODO: was geht hier ab?!?!? */
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