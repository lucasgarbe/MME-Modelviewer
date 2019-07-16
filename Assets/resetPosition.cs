using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Setzt die Position des Objektes in die Mitte des Drehteller.
 * Gleichzeitig wird die Rotation um die X und Z Achse
 * und die Bewegung auf der Z Achse gesperrt.
 */
public class resetPosition : MonoBehaviour
{ 
    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.localPosition;
        newPos.y = 0.05f;
        transform.localPosition = newPos;
        transform.rotation = new Quaternion();
        Rigidbody body = gameObject.GetComponent<Rigidbody>();
        body.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
}
