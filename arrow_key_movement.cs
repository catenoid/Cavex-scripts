using UnityEngine;
using System.Collections;

public class arrow_key_movement : MonoBehaviour {
    Vector3 velocity = new Vector3(0,0,0);
    bool cavexFlag;
    Vector3 moveUp;
    Vector3 moveLeft;

    Vector3 convexMoveUp = new Vector3(-1,0,-1);
    Vector3 convexMoveLeft = new Vector3(1,0,-1);
    Vector3 concaveMoveUp = new Vector3(-0.2357023f, -0.9428091f, -0.2357023f); // I have failed the Linear Algebra gods
    Vector3 concaveMoveLeft = new Vector3(-1,0,1);
	
	Matrix4x4 reflection = new Matrix4x4 ();
    
    void Start() {
        cavexFlag = true;
        moveUp = convexMoveUp;
        moveLeft = convexMoveLeft;
        
		reflection.SetRow (0, new Vector4(0.333f, -0.666f, -0.666f, 0.666f));
		reflection.SetRow (1, new Vector4(-0.666f, 0.333f, -0.666f, 0.666f));
		reflection.SetRow (2, new Vector4(-0.666f, -0.666f, 0.333f, 0.666f));
		reflection.SetRow (3, new Vector4(0, 0, 0, 1));
    }
    
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            transform.position = reflection.MultiplyPoint3x4(transform.position);
            
            if (cavexFlag) {
                moveUp = concaveMoveUp;
                moveLeft = concaveMoveLeft;
                cavexFlag = false;
            } else {
                moveUp = convexMoveUp;
                moveLeft = convexMoveLeft;
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
            velocity -= moveLeft;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            velocity += moveLeft;
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            velocity -= moveUp;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow)) {
            velocity += moveUp;
        }
        
        transform.position += 0.05F*velocity;
	}
}
