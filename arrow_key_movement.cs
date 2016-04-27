using UnityEngine;
using System.Collections;

public class arrow_key_movement : MonoBehaviour {
    Vector3 velocity = new Vector3(0,0,0);
    Vector3 moveUp = new Vector3(-1,0,-1);
    Vector3 moveLeft = new Vector3(1,0,-1);
    
    public void Invert() {
        transform.position -= 0.5f*Vector3.up;  // 0.5 to offset the centre of the sphere
        transform.position -= 2*(transform.position.y)*Vector3.up; // Reflect over the y-axis
        transform.position += 0.5f*Vector3.up;
        moveUp = -moveUp;
        moveLeft = -moveLeft;
    } 
    
    void Update () {
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
