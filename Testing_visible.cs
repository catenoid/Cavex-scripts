using UnityEngine; using System.Collections;
public class Testing_visible : Visible_surface {
Vector3[] verts = new Vector3[] {
new Vector3(-2, 1, -1), new Vector3(-2, 1, 0), new Vector3(0, 1, 0),
new Vector3(-2, 1, -1), new Vector3(0, 1, 0), new Vector3(0, 1, -1),
new Vector3(0, 0, 0), new Vector3(-2, 1, 0), new Vector3(-3, 0, 0),
new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(-2, 1, 0),
new Vector3(-2, 2, -2), new Vector3(-2, 2, -1), new Vector3(0, 2, -1),
new Vector3(-2, 2, -2), new Vector3(0, 2, -1), new Vector3(0, 2, -2),
new Vector3(0, 1, -1), new Vector3(-2, 2, -1), new Vector3(-2, 1, -1),
new Vector3(0, 1, -1), new Vector3(0, 2, -1), new Vector3(-2, 2, -1),
new Vector3(0, 1, -1), new Vector3(0, 2, -2), new Vector3(0, 2, -1),
new Vector3(0, 1, -2), new Vector3(0, 0, 0), new Vector3(0, 0, -3),
new Vector3(0, 1, -2), new Vector3(0, 1, 0), new Vector3(0, 0, 0),
new Vector3(0, 1, -2), new Vector3(0, 1, -1), new Vector3(0, 1, 0),
new Vector3(0, 1, -2), new Vector3(0, 2, -2), new Vector3(0, 1, -1),
}; public Testing_visible() {concaveVerts = verts;} }