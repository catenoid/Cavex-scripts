using UnityEngine;
using System.Collections;

abstract public class Hidden_surface : Surface {
    protected Vector3[] vertices; // needed
    protected bool initially_visible = true;
    int[] indices;
    
    void Start() {
        // Assign indices. The vertices are added in triples corresponding to a mesh triangle, so indices just increment
        indices = new int[vertices.Length];
        for (int i=0; i<vertices.Length; i++) {
            indices[i] = i;
        }
        
        // Create the mesh
        Mesh msh = new Mesh();
        msh.Clear();
        msh.vertices = vertices;
        msh.triangles = indices;
        msh.RecalculateNormals();
        
        // Set up game object with mesh
        gameObject.GetComponent<MeshFilter>().mesh = msh;
        gameObject.GetComponent<MeshCollider>().sharedMesh = msh;
    
        if (!initially_visible) {
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<MeshCollider>().enabled = false;
        }
    }
    
    override public void Invert() {
        gameObject.GetComponent<Renderer>().enabled ^= true;
        gameObject.GetComponent<MeshCollider>().enabled ^= true;
    }
}