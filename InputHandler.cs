using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {
    public Camera_flip cf;
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            cf.InvertCommand();
        }
    }
}