using UnityEngine;
using System.Collections;

public class Camera_flip : MonoBehaviour {
    public Sun sun;
    public Mesh_parent[] map;

    public float rotationSpeed = 300;

    bool rotating = false;
    bool clockwise = true;
    float z = 0;
    float nextZ;
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (rotating) {
                clockwise = !clockwise;
                sun.Reverse();
            } else {
                clockwise = true;
                rotating = true;
                sun.ForceSunset();
            }
        }
        if (rotating) {
            if (clockwise) {
                nextZ = z + Time.deltaTime * rotationSpeed;
                if (z >= 0 && z < 180) {
                    if (nextZ >= 180) {
                        nextZ = 180;
                        DawnOnAlternatePlane();
                    }
                } else if (z >= 180) {
                    if (nextZ >= 360) {
                        nextZ = 0;
                        DawnOnAlternatePlane();
                    }
                }
            } else {
                // counter-clockwise rotation
                nextZ = z - Time.deltaTime * rotationSpeed;
                if (z >= 0 && z < 180) {
                    if (nextZ < 0) {
                        rotating = false;
                        nextZ = 0;
                        sun.AbortedInversion();
                    }
                } else if (z >= 180) {
                    if (nextZ < 180) {
                        rotating = false;
                        nextZ = 180;
                        sun.AbortedInversion();
                    }
                }
            }
            transform.rotation = Quaternion.Euler(35.26f,225f,nextZ);
            z = nextZ;
        }
    }
    void DawnOnAlternatePlane() {
        rotating = false;
        sun.NewDay();
        foreach (Mesh_parent terrain in map) {
            terrain.Invert();
        }
        // swap concave, convex only
    }
}