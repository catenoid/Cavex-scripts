using UnityEngine;
using System.Collections;

public class Mesh_child : Mesh_parent {
    Vector3[] verts = new Vector3[] {
        // Stairs
        new Vector3(0, 0, 0),       new Vector3(-2, 1, 0),      new Vector3(-2, 0, 0),
        new Vector3(0, 0, 0),       new Vector3(0, 1, 0),       new Vector3(-2, 1, 0),
        new Vector3(0, 1, 0),       new Vector3(-2, 1, -1),     new Vector3(-2, 1, 0),
        new Vector3(0, 1, 0),       new Vector3(0, 1, -1),      new Vector3(-2, 1, -1),
        new Vector3(0, 1, -1),      new Vector3(-2, 2, -1),     new Vector3(-2, 1, -1),
        new Vector3(0, 1, -1),      new Vector3(0, 2, -1),      new Vector3(-2, 2, -1),
        new Vector3(0, 2, -1),      new Vector3(-2, 2, -2),     new Vector3(-2, 2, -1),
        new Vector3(0, 2, -1),      new Vector3(0, 2, -2),      new Vector3(-2, 2, -2),
        
        // Side plate
        new Vector3(0,0,-2),        new Vector3(0, 1, 0),       new Vector3(0, 0, 0),
        new Vector3(0,0,-2),        new Vector3(0, 1, -1),      new Vector3(0, 1, 0),
        new Vector3(0,0,-2),        new Vector3(0, 2, -1),      new Vector3(0, 1, -1),
        new Vector3(0,0,-2),        new Vector3(0, 2, -2),      new Vector3(0, 2, -1),
        };
        
    public Mesh_child() {concaveVerts = verts;}
    
    void OnCollisionEnter(Collision collision) {
        Debug.Log("Collision STAIRS");
    }
}