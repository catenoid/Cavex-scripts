using UnityEngine;
using System.Collections;

public class Camera_flip : MonoBehaviour {
    public Sun sun;
    public Surface[] map;
    public arrow_key_movement player;
    public Ambient_flip amb;

    public float rotationSpeed = 100;

    bool rotating = false;
    bool clockwise = true;
    float z = 0;
    float nextZ;
    
    float y_euler = 225f;
    
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
                if (nextZ >= 180) {
                    DawnOnAlternatePlane();
                }
            } else {
                nextZ = z - Time.deltaTime * rotationSpeed;
                if (nextZ < 0) {
                    InversionCancelled();
                }
            }
            transform.rotation = Quaternion.Euler(35.26f,y_euler,nextZ);
            z = nextZ;
        }
    }
    
    void InversionCancelled() {
        rotating = false;
        nextZ = 0;
        sun.AbortedInversion();
    }
    
    void DawnOnAlternatePlane() {
        rotating = false;
        sun.NewDay();
        amb.Invert();
        foreach (Surface surface in map) {
            surface.Invert();
        }
        player.Invert();
        float offset = transform.position.x;
        Vector3 camera_displacement = new Vector3(offset, 0, offset);
        transform.position -= 2*camera_displacement;
        y_euler = 270 - y_euler;
        nextZ = 0;
    }
}