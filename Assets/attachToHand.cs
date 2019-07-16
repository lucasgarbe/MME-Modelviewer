using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

/** Klasse hängt Menü an die Linke Hand
 */
public class attachToHand : MonoBehaviour
{
    public GameObject _HandController; /**< verlinkter HandController der Szene */
    private HandModel _HandModel; /**< verlinktes HandModel an das das Menü gehängt werden soll */
    private LeapServiceProvider LSP; /**< Leap Service Provider für die Frames */

    /** Hier wird beim Start der LeapServiceProvider gesetzt
     */
    void Start()
    {
        LSP = FindObjectOfType<LeapServiceProvider>() as LeapServiceProvider;
    }

    /** Während jedes Frames wird die Position des Menüs auf eine Neue Position gesetzt,
     * die vom HandObject ausgehend bestimmt wird
     *
     */ 
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
