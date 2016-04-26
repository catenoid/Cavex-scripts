using UnityEngine;
using System.Collections;

public class Back_of_stairs : Convex_only {
    Vector3[] my_verts = new Vector3[] {
        // Square wall
        new Vector3(0, 0, -2),      new Vector3(-2, 2, -2),     new Vector3(0, 2, -2),
        new Vector3(0, 0, -2),      new Vector3(-2, 0, -2),     new Vector3(-2, 2, -2),
        
        // L-shaped wall
        new Vector3(-2, 0, 0),      new Vector3(-2, 2, -2),     new Vector3(-2, 0, -2),
        new Vector3(-2, 0, 0),      new Vector3(-2, 1, 0),      new Vector3(-2, 1, -1),
        new Vector3(-2, 1, -1),     new Vector3(-2, 2, -1),     new Vector3(-2, 2, -2),
    };
    
    public Back_of_stairs() {
        vertices = my_verts;
    }
}