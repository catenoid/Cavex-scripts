using UnityEngine;
using System.Collections;

// Make sure you add a mesh renderer or else it'll be invisible

public class large_mesh : MonoBehaviour {
	Vector3[] concaveVerts = new Vector3[] {
        /* From the Manual, paraphrased:
        
        If all three surface normals are pointing in the same direction then the triangle will be uniformly lit: required for a model of a cube, but the interpolation of the normals can be used to approximate a smooth, curved surface. To get crisp edges, it is necessary to double up vertices at each edge since both of the two adjacent triangles will need their own separate normals.
        
        */

        // Stairs
		new Vector3(0, 0, 0), 		new Vector3(-2, 1, 0),      new Vector3(-2, 0, 0),
		new Vector3(0, 0, 0),       new Vector3(0, 1, 0),       new Vector3(-2, 1, 0),
        new Vector3(0, 1, 0), 		new Vector3(-2, 1, -1),     new Vector3(-2, 1, 0),
		new Vector3(0, 1, 0),       new Vector3(0, 1, -1),      new Vector3(-2, 1, -1),
        new Vector3(0, 1, -1), 		new Vector3(-2, 2, -1),     new Vector3(-2, 1, -1),
		new Vector3(0, 1, -1),      new Vector3(0, 2, -1),      new Vector3(-2, 2, -1),
        new Vector3(0, 2, -1), 		new Vector3(-2, 2, -2),     new Vector3(-2, 2, -1),
		new Vector3(0, 2, -1),      new Vector3(0, 2, -2),      new Vector3(-2, 2, -2),
        
        // Side plate
        new Vector3(0,0,-2),        new Vector3(0, 1, 0), 		new Vector3(0, 0, 0),
        new Vector3(0,0,-2),        new Vector3(0, 1, -1), 		new Vector3(0, 1, 0),
        new Vector3(0,0,-2),        new Vector3(0, 2, -1), 		new Vector3(0, 1, -1),
        new Vector3(0,0,-2),        new Vector3(0, 2, -2), 		new Vector3(0, 2, -1),
	};
	Vector3[] convexVerts;
	int[] indices;
	Matrix4x4 reflection = new Matrix4x4 ();
	bool cavexFlag;
    
	// Use this for initialization
	void Start () {
		cavexFlag = true;
        convexVerts = new Vector3[concaveVerts.Length];
        indices = new int[concaveVerts.Length];
        
		// Populate the reflection matrix
		reflection.SetRow (0, new Vector4(0.333f, -0.666f, -0.666f, 0.666f));
		reflection.SetRow (1, new Vector4(-0.666f, 0.333f, -0.666f, 0.666f));
		reflection.SetRow (2, new Vector4(-0.666f, -0.666f, 0.333f, 0.666f));
		reflection.SetRow (3, new Vector4(0, 0, 0, 1));
		
        // Assign indices. The vertices are added in triples corresponding to a mesh triangle
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
	}
	
	// Update is called once per frame
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
