using UnityEngine;
using System.Collections;

// Make sure you add a mesh renderer (with a material) and mesh filter or else it'll be invisible

abstract public class Mesh_parent : MonoBehaviour {
    protected Vector3[] concaveVerts; //needed
    Vector3[] convexVerts;
    int[] indices;
    bool cavexFlag = true;
    
    void Start () {
        convexVerts = new Vector3[concaveVerts.Length];
        indices = new int[concaveVerts.Length];
        
        // Perform reflection
        for (int i=0; i<concaveVerts.Length; i++) {
            convexVerts[i] = concaveVerts[i] - 2*concaveVerts[i].y*Vector3.up;
        }
        
        // The vertices are added in triples corresponding to a mesh triangle. Generate the sequence 0 1 2 3 4 5 ...
        for (int i=0; i<concaveVerts.Length; i++) {
            indices[i] = i;
        }
        
        // Create the mesh
        Mesh msh = new Mesh();
        msh.Clear();
        msh.vertices = concaveVerts;
        msh.triangles = indices;
        msh.RecalculateNormals();
        
        // Set up game object with mesh
        gameObject.GetComponent<MeshFilter>().mesh = msh;
        gameObject.GetComponent<MeshCollider>().sharedMesh = msh;
    }
    
    public void Invert() {
        Mesh msh = gameObject.GetComponent<MeshFilter>().mesh;
        if (cavexFlag) {
            msh.vertices = convexVerts;
            cavexFlag = false;
        } else {
            msh.vertices = concaveVerts;
            cavexFlag = true;
        }
        msh.RecalculateNormals();
        gameObject.GetComponent<MeshCollider>().sharedMesh = msh;
    }
}
