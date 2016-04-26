using UnityEngine;
using System.Collections;

abstract public class Hidden_terrain : MonoBehaviour {
    protected bool cavexFlag; // needed
    protected Vector3[] vertices; // needed
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
    
        if (cavexFlag) {
            gameObject.SetActive(true);
        } else {
            gameObject.SetActive(false);
        }
    }
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (cavexFlag) {
                gameObject.SetActive(false);
                cavexFlag = false;
            } else {
                gameObject.SetActive(true);
                cavexFlag = true;
            }
        }
    }
}