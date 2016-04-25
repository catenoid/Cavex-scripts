using UnityEngine;
using System.Collections;

public class Reflection_flip : MonoBehaviour {
    // Reflection probe position found by reflecting the camera over the mirror plane
    // Mirror plane normals are calculated in the player movement script as the cross product of arrow key movement vectors
    Vector3 position1 = new Vector3(-2.33333f, 11.6666f, -2.33333f);
    Vector3 position2 = new Vector3(7f,-7f,7f);
    Vector3 target;
    bool cavexFlag = true;
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (cavexFlag) {
                target = position1;
                cavexFlag = false;
            } else {
                target = position2;
                cavexFlag = true;
            }
            transform.position = target;
        }
    }
}