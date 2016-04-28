using UnityEngine;
using System.Collections;

public class Ambient_flip : MonoBehaviour {
    Quaternion view1 = Quaternion.Euler(50,150,0);
    Quaternion view2 = Quaternion.Euler(50,330,0);
    bool cavexFlag = true;
    
    public void Invert() {
        if (cavexFlag) {
            transform.rotation = view1;
        } else {
            transform.rotation = view2;
        }
        cavexFlag = !cavexFlag;
    }
}