using UnityEngine;
using System.Collections;

public class Light_flip : MonoBehaviour {
    Quaternion view1 = Quaternion.Euler(330f,180f,0f); // Guesswork
    Quaternion view2 = Quaternion.Euler(50f,330f,0f);
    Quaternion targetView;
    bool cavexFlag = true;
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (cavexFlag) {
                targetView = view1;
                cavexFlag = false;
            } else {
                targetView = view2;
                cavexFlag = true;
            }
            transform.rotation = targetView;
        }
    }
}