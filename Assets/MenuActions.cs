using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Zuständig für alle Aktionen, die das Menü an der Hand ausführen kann
 *
 */
public class MenuActions : MonoBehaviour
{
    public bool isActive; /**< speichert den Anzeigezustand des Menüs */
    public Camera cam; /**< verweist auf die Kamera der Szene */

    /** Initial ist das Menü nicht sichtbar  */
    void Start()
    {
        HideMenu();
    }

    /** Blendet Menü aus, indem es an einer nicht sichtbaren Position platziert wird
     *  und isActive wird auf false gesetzt
     */
    public void HideMenu()
    {
        transform.position = new Vector3(-10, -10, -10);
        isActive = false;
    }

    /** Blendet Menü ein
     * isActive wird auf true gesetzt
     */
    public void ShowMenu()
    {
        isActive = true;
    }

    /** Setzt die Hintergrundfarbe der Szene auf blau */
    public void BackgroundColorBlue()
    {
        cam.backgroundColor = new Color(0.1f, 0.001f, 0.4f, 1f);
    }

    /** Setzt die Hintergrundfarbe der Szene auf grau */
    public void BackgroundColorGrey()
    {
        cam.backgroundColor = new Color(0.3f, 0.3f, 0.3f, 0f);
    }

    /** Setzt die Hintergrundfarbe der Szene auf grün */
    public void BackgroundColorGreen()
    {
        cam.backgroundColor = new Color(0.1f, 0.4f, 0.001f, 1f);
    }
}
