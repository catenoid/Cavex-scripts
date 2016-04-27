using UnityEngine;
using System.Collections;

public class Ground_plane : Mesh_parent {
    public Ground_plane () {
        Vector3[] stairVerts = new Vector3[] {
            new Vector3(0, 0, 0),
            new Vector3(-2, 0, 0),
            new Vector3(-2, 1, 0),
            new Vector3(-2, 1, -1),
            new Vector3(-2, 2, -1),
            new Vector3(-2, 2, -2),
            new Vector3(0, 2, -2),
            new Vector3(0,0,-2),
        };
        
        // Projection vector used for culling the parts of the ground plane hidden by the stairs
        Vector3 cameraView = new Vector3(-1,-1,-1);
        
        // Project the extremities of the staircase into the ground plane, counter-clockwise from the corner nearest the camera
        Vector3[] culled = new Vector3[stairVerts.Length];
        float t;
        for (int i=0; i<stairVerts.Length; i++) {
            t = - stairVerts[i].y / cameraView.y;
            culled[i] = stairVerts[i] + t*cameraView;
        }
        
        // The bounding points of the plane, counter-clockwise from the corner nearest the camera
        Vector3[] bounds = new Vector3 [] {
            new Vector3(10,0,10),
            new Vector3(-10,0,10),
            new Vector3(-10,0,-10),
            new Vector3(10,0,-10),
        };
        
        // Populate concaveVerts with the required bounding points and cull points
        concaveVerts = new Vector3[] {
            bounds[0], culled[0], bounds[1],
            culled[0], culled[1], bounds[1],
            culled[1], culled[2], bounds[1],
            culled[2], bounds[2], bounds[1],
            culled[2], culled[4], bounds[2],
            culled[3], culled[4], culled[2],
            culled[5], bounds[2], culled[4],
            culled[6], bounds[2], culled[5],
            bounds[3], bounds[2], culled[6],
            bounds[3], culled[6], culled[7],
            bounds[3], culled[7], bounds[0],
            bounds[0], culled[7], culled[0],
        };
    }
}