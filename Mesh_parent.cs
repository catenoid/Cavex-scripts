using UnityEngine;
using System.Collections;

// Make sure you add a mesh renderer (with a material) and mesh filter or else it'll be invisible

abstract public class Mesh_parent : MonoBehaviour {
	protected Vector3[] concaveVerts; //needed
	Vector3[] convexVerts;
	int[] indices;
	Matrix4x4 reflection = new Matrix4x4 ();
	bool cavexFlag = true;
    
	void Start () {
        convexVerts = new Vector3[concaveVerts.Length];
        indices = new int[concaveVerts.Length];
        
		// Populate the reflection matrix
		reflection.SetRow (0, new Vector4(0.333f, -0.666f, -0.666f, 0.666f));
		reflection.SetRow (1, new Vector4(-0.666f, 0.333f, -0.666f, 0.666f));
		reflection.SetRow (2, new Vector4(-0.666f, -0.666f, 0.333f, 0.666f));
		reflection.SetRow (3, new Vector4(0, 0, 0, 1));
		
        // Assign indices. The vertices are added in triples corresponding to a mesh triangle, so indices just increment
        for (int i=0; i<concaveVerts.Length; i++) {
			indices[i] = i;
		}
        
		// Perform reflection
		for (int i=0; i<concaveVerts.Length; i++) {
			convexVerts[i] = reflection.MultiplyPoint3x4(concaveVerts[i]);
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
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			Mesh msh = gameObject.GetComponent<MeshFilter>().mesh;
			if (cavexFlag) {
				msh.vertices = convexVerts;
				cavexFlag = false;
			} else {
				msh.vertices = concaveVerts;
				cavexFlag = true;
			}
            msh.RecalculateNormals();
		}
	}
}
