using UnityEngine;
using System.Collections;

public class Interior_of_cave : Concave_only {
    // Good luck with this one!
    // Do it convex, then flip the vertices
    Vector3[] my_alt_verts = new Vector3[] {
        // Lower floor
        new Vector3(0, 2, -2),       new Vector3(-2, 2, -4),     new Vector3(-2, 2, -2),
        new Vector3(-2, 2, -1),      new Vector3(-2, 2, -4),     new Vector3(-3, 2, -2),
        new Vector3(-2, 2, -1),      new Vector3(-3, 2, -2),     new Vector3(-3, 2, -1),
        new Vector3(-3, 2, -2),      new Vector3(-2, 2, -4),     new Vector3(-4, 2, -4),
        new Vector3(-3, 2, -2),      new Vector3(-4, 2, -4),     new Vector3(-4, 2, -3),
        
        // Upper floor
        new Vector3(-2, 1, 0),       new Vector3(-2, 1, -1),     new Vector3(-3, 1, -1),
        
        // 5 walls of 2 units height
        new Vector3(-3, 0, -1),      new Vector3(-3, 2, -1),     new Vector3(-3, 2, -2),
        new Vector3(-3, 0, -1),      new Vector3(-3, 2, -2),     new Vector3(-3, 0, -2),
        
        new Vector3(-3, 0, -2),      new Vector3(-3, 2, -2),     new Vector3(-4, 2, -3),
        new Vector3(-3, 0, -2),      new Vector3(-4, 2, -3),     new Vector3(-4, 0, -3),
        
        new Vector3(-4, 0, -3),      new Vector3(-4, 2, -3),     new Vector3(-4, 2, -4),
        new Vector3(-4, 0, -3),      new Vector3(-4, 2, -4),     new Vector3(-4, 0, -4),
        
        new Vector3(-4, 0, -4),      new Vector3(-4, 2, -4),     new Vector3(-2, 2, -4),
        new Vector3(-4, 0, -4),      new Vector3(-2, 2, -4),     new Vector3(-2, 0, -4),
        
        new Vector3(-2, 0, -4),      new Vector3(-2, 2, -4),     new Vector3(0, 2, -2), 
        new Vector3(-2, 0, -4),      new Vector3(0, 2, -2),      new Vector3(0, 0, -2), 
        
        // 2 walls of unit height
        new Vector3(-2, 1, -1),      new Vector3(-2, 2, -1),     new Vector3(-3, 2, -1),
        new Vector3(-2, 1, -1),      new Vector3(-3, 2, -1),     new Vector3(-3, 1, -1),
        
        new Vector3(-2, 0, 0),       new Vector3(-2, 1, 0),      new Vector3(-3, 1, -1),  
        new Vector3(-2, 0, 0),       new Vector3(-3, 1, -1),     new Vector3(-3, 0, -1),
    };
    
    Matrix4x4 reflection = new Matrix4x4 ();
    Vector3[] my_verts;
    
    public Interior_of_cave() {
        // Reflect all the vertices
        my_verts = new Vector3[my_alt_verts.Length];
        
        // Populate the reflection matrix
        reflection.SetRow (0, new Vector4(0.333f, -0.666f, -0.666f, 0.666f));
        reflection.SetRow (1, new Vector4(-0.666f, 0.333f, -0.666f, 0.666f));
        reflection.SetRow (2, new Vector4(-0.666f, -0.666f, 0.333f, 0.666f));
        reflection.SetRow (3, new Vector4(0, 0, 0, 1));
        
        // Perform reflection
        for (int i=0; i<my_alt_verts.Length; i++) {
            my_verts[i] = reflection.MultiplyPoint3x4(my_alt_verts[i]);
        }
        
        vertices = my_verts;
    }
}