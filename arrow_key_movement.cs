using UnityEngine;
using System.Collections;

public class arrow_key_movement : MonoBehaviour {
    Vector3 velocity = new Vector3(0,0,0);
    bool cavexFlag;
    
    Vector3 moveUp = new Vector3(-1,0,1);
    Vector3 moveLeft = new Vector3(-1,0,-1);
    Vector3 moveRight = new Vector3(1,0,1);
    Vector3 moveDown = new Vector3(1,0,-1);
	
    void Start() {
        cavexFlag = true;
    }
    
	// Update is called once per frame
	void Update () {
        // Player inverts with the terrain
        if (Input.GetKeyDown(KeyCode.Space)) {
            if(cavexFlag) {
                transform.position += 2*Vector3.down;
                cavexFlag = false;
            } else {
                transform.position -= 2*Vector3.down;
                cavexFlag = true;
            }
        }
    
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            velocity += moveUp;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow)) {
            velocity -= moveUp;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            velocity += moveLeft;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            velocity -= moveLeft;
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            velocity += moveRight;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            velocity -= moveRight;
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            velocity += moveDown;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow)) {
            velocity -= moveDown;
        }
        
        transform.position += 0.05F*velocity;
	}
}
