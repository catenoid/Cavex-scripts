using UnityEngine;
using System.Collections;

public class Camera_flip : MonoBehaviour {
    public Sun sun;
    public Mesh_parent[] map;
    public Hidden_terrain[] hidden_map;
    public arrow_key_movement player;

    public float rotationSpeed = 300;

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
        foreach (Mesh_parent terrain in map) {
            terrain.Invert();
        }
        foreach (Hidden_terrain terrain in hidden_map) {
            terrain.Invert();
        }
        player.Invert();
        float offset = transform.position.x;
        Vector3 camera_displacement = new Vector3(offset, 0, offset);
        transform.position -= 2*camera_displacement;
        y_euler = 270 - y_euler;
        nextZ = 0;
    }
}