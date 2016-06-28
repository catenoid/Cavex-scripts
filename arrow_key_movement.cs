using UnityEngine;
using System.Collections;

public class arrow_key_movement : MonoBehaviour {
    Vector3 moveUp = new Vector3(-1,0,-1);
    Vector3 moveLeft = new Vector3(1,0,-1);
    Rigidbody rb;
    public float speed = 10;
    
    void Start() {
        rb = GetComponent<Rigidbody>();
    }
    
    public void Invert() {
        transform.position -= 0.5f*Vector3.up;  // 0.5 to offset the centre of the sphere
        transform.position -= 2*(transform.position.y)*Vector3.up; // Reflect over the y-axis
        transform.position += 0.5f*Vector3.up;
        moveUp = -moveUp;
        moveLeft = -moveLeft;
    } 
    
    void FixedUpdate () {
		float horizontal = Input.GetAxis ("MovementHorizontal");
		float vertical = Input.GetAxis ("MovementVertical");
		Vector3 movement = moveUp*vertical -moveLeft*horizontal;
		rb.AddForce(movement*speed);
    }
}
