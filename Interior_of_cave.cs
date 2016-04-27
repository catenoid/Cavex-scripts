using UnityEngine;
using System.Collections;

public class Interior_of_cave : Concave_only {
    Vector3[] my_verts = new Vector3[] {
        // Lower floor
        new Vector3(0, -2, -2),       new Vector3(-2, -2, -4),     new Vector3(-2, -2, -2),
        new Vector3(-2, -2, -1),      new Vector3(-2, -2, -4),     new Vector3(-3, -2, -2),
        new Vector3(-2, -2, -1),      new Vector3(-3, -2, -2),     new Vector3(-3, -2, -1),
        new Vector3(-3, -2, -2),      new Vector3(-2, -2, -4),     new Vector3(-4, -2, -4),
        new Vector3(-3, -2, -2),      new Vector3(-4, -2, -4),     new Vector3(-4, -2, -3),
        
        // Upper floor
        new Vector3(-2, -1, 0),       new Vector3(-2, -1, -1),     new Vector3(-3, -1, -1),
        
        // 5 walls of 2 units height
        new Vector3(-3, 0, -1),      new Vector3(-3, -2, -1),     new Vector3(-3, -2, -2),
        new Vector3(-3, 0, -1),      new Vector3(-3, -2, -2),     new Vector3(-3, 0, -2),
        
        new Vector3(-3, 0, -2),      new Vector3(-3, -2, -2),     new Vector3(-4, -2, -3),
        new Vector3(-3, 0, -2),      new Vector3(-4, -2, -3),     new Vector3(-4, 0, -3),
        
        new Vector3(-4, 0, -3),      new Vector3(-4, -2, -3),     new Vector3(-4, -2, -4),
        new Vector3(-4, 0, -3),      new Vector3(-4, -2, -4),     new Vector3(-4, 0, -4),
        
        new Vector3(-4, 0, -4),      new Vector3(-4, -2, -4),     new Vector3(-2, -2, -4),
        new Vector3(-4, 0, -4),      new Vector3(-2, -2, -4),     new Vector3(-2, 0, -4),
        
        new Vector3(-2, 0, -4),      new Vector3(-2, -2, -4),     new Vector3(0, -2, -2), 
        new Vector3(-2, 0, -4),      new Vector3(0, -2, -2),      new Vector3(0, 0, -2), 
        
        // 2 walls of unit height
        new Vector3(-2, -1, -1),      new Vector3(-2, -2, -1),     new Vector3(-3, -2, -1),
        new Vector3(-2, -1, -1),      new Vector3(-3, -2, -1),     new Vector3(-3, -1, -1),
        
        new Vector3(-2, 0, 0),       new Vector3(-2, -1, 0),      new Vector3(-3, -1, -1),  
        new Vector3(-2, 0, 0),       new Vector3(-3, -1, -1),     new Vector3(-3, 0, -1),
    };
    
    public Interior_of_cave() {
        vertices = my_verts;
    }
}