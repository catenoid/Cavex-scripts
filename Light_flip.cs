using UnityEngine;
using System.Collections;

public class Light_flip : MonoBehaviour {
    Quaternion targetView;
    bool cavexFlag = true;
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (cavexFlag) {
                targetView = Quaternion.Euler(330f,180f,0f); // Guesswork
                cavexFlag = false;
            } else {
                targetView = Quaternion.Euler(50f,330f,0f);
                cavexFlag = true;
            }
            transform.rotation = targetView;
        }
    }
}