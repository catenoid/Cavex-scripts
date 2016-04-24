using UnityEngine;
using System.Collections;

public class Camera_flip : MonoBehaviour {
    bool cavexFlag = true;
    Quaternion targetView;
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (cavexFlag) {
                targetView = Quaternion.Euler(35.26f,225f,180f);
                cavexFlag = false;
            } else {
                targetView = Quaternion.Euler(35.26f,225f,0f);
                cavexFlag = true;
            }
            transform.rotation = targetView;
        }
    }
}