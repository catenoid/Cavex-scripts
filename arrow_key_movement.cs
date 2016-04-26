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
    
    Vector3 convexMoveDown;
    Vector3 concaveMoveDown;
    float g = 9.8f;
    
    Matrix4x4 reflection = new Matrix4x4 ();
    
    void Start() {
        cavexFlag = true;
        moveUp = convexMoveUp;
        moveLeft = convexMoveLeft;
        
        convexMoveDown = Vector3.Cross(convexMoveUp, convexMoveLeft).normalized;
        concaveMoveDown = Vector3.Cross(concaveMoveUp, concaveMoveLeft).normalized;
        
        reflection.SetRow (0, new Vector4(0.333f, -0.666f, -0.666f, 0.666f));
        reflection.SetRow (1, new Vector4(-0.666f, 0.333f, -0.666f, 0.666f));
        reflection.SetRow (2, new Vector4(-0.666f, -0.666f, 0.333f, 0.666f));
        reflection.SetRow (3, new Vector4(0, 0, 0, 1));
    }
    
    void OnCollisionEnter(Collision collision) {
        Debug.Log("Collision PLAYER SPHERE");
    }
    
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (cavexFlag) {
                // On inversion, the player object appears to become it's reflection, were the floor a mirror.
                transform.position += convexMoveDown;
                moveUp = concaveMoveUp;
                moveLeft = concaveMoveLeft;
                cavexFlag = false;
                Physics.gravity = g * concaveMoveDown;
            } else {
                transform.position += concaveMoveDown;
                moveUp = convexMoveUp;
                moveLeft = convexMoveLeft;
                cavexFlag = true;
                Physics.gravity = g * convexMoveDown;
            }
            transform.position = reflection.MultiplyPoint3x4(transform.position);
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
