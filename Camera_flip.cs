using UnityEngine;
using System.Collections;

public class Camera_flip : MonoBehaviour {
    bool cavexFlag = true;
    Quaternion targetView;
    bool rotating = false;
    bool clockwise = true;
    float z = 0;
    float nextZ;
    float rotationSpeed = 60;
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (rotating && clockwise) {
                clockwise = false;
            } else {
                clockwise = true;
                rotating = true;
            }
        }
        if (rotating) {
            if (clockwise) {
                nextZ = z + Time.deltaTime * rotationSpeed;
                if (z >= 0 && z < 180) {
                    if (nextZ >= 180) {
                        rotating = false;
                        nextZ = 180;
                    }
                } else if (z >= 180) {
                    if (nextZ >= 360) {
                        rotating = false;
                        nextZ = 0;
                    }
                }
            } else {
                // counter-clockwise rotation
                nextZ = z - Time.deltaTime * rotationSpeed;
                if (z >= 0 && z < 180) {
                    if (nextZ < 0) {
                        rotating = false;
                        nextZ = 0;
                    }
                } else if (z >= 180) {
                    if (nextZ < 180) {
                        rotating = false;
                        nextZ = 180;
                    }
                }
            }
            transform.rotation = Quaternion.Euler(35.26f,225f,nextZ);
            z = nextZ;
        }
    }
}