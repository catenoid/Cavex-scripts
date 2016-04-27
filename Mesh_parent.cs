using UnityEngine;
using System.Collections;

// Make sure you add a mesh renderer (with a material) and mesh filter or else it'll be invisible

abstract public class Mesh_parent : MonoBehaviour {
    protected Vector3[] concaveVerts; //needed
    Vector3[] convexVerts;
    
    int[] concaveIndices;
    int[] convexIndices;
    
    bool cavexFlag = true;
    
    void Start () {
        convexVerts = new Vector3[concaveVerts.Length];
        
        concaveIndices = new int[concaveVerts.Length];
        convexIndices = new int[convexVerts.Length];
        
        // Perform reflection
        for (int i=0; i<concaveVerts.Length; i++) {
            convexVerts[i] = concaveVerts[i] - 2*concaveVerts[i].y*Vector3.up;
        }
        
        // The vertices are added in triples corresponding to a mesh triangle. Generate the sequence 0 1 2 3 4 5 ...
        for (int i=0; i<concaveVerts.Length; i++) {
            concaveIndices[i] = i;
        }

        // The surface normals invert. Generate the sequence 0 2 1 3 5 4 6 8 7 ...
        // Ok, I was wrong
        for (int i=0; i<convexVerts.Length; i++) {
            convexIndices[i] = i; //3*(i/3) + (i+1)%3 - 1;
        }
        
        // Create the mesh
        Mesh msh = new Mesh();
        msh.Clear();
        msh.vertices = concaveVerts;
        msh.triangles = concaveIndices;
        msh.RecalculateNormals();
        
        // Set up game object with mesh
        gameObject.GetComponent<MeshFilter>().mesh = msh;
        gameObject.GetComponent<MeshCollider>().sharedMesh = msh;
    }
    
    public void Invert() {
        Mesh msh = gameObject.GetComponent<MeshFilter>().mesh;
        if (cavexFlag) {
            msh.vertices = convexVerts;
            msh.triangles = convexIndices;
            cavexFlag = false;
        } else {
            msh.vertices = concaveVerts;
            msh.triangles = concaveIndices;
            cavexFlag = true;
        }
        msh.RecalculateNormals();
        gameObject.GetComponent<MeshCollider>().sharedMesh = msh;
    }
}
