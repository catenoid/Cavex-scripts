using UnityEngine; using System.Collections;
public class Testing_convex : Convex_only {
Vector3[] my_verts = new Vector3[] {
new Vector3(-1, 0, -3), new Vector3(-2, 0, -4), new Vector3(-4, 0, -4),
new Vector3(-1, 0, -3), new Vector3(-4, 0, -4), new Vector3(-4, 0, -3),
new Vector3(-3, 0, -2), new Vector3(-3, 0, -1), new Vector3(-3, 0, 0),
new Vector3(-3, 0, -2), new Vector3(-3, 0, 0), new Vector3(-2, 0, 0),
new Vector3(-3, 0, -2), new Vector3(-2, 0, 0), new Vector3(-2, 0, -1),
new Vector3(-2, 0, -2), new Vector3(0, 0, -2), new Vector3(0, 0, -3),
new Vector3(-2, 0, -2), new Vector3(0, 0, -3), new Vector3(-1, 0, -3),
new Vector3(-2, 0, -2), new Vector3(-1, 0, -3), new Vector3(-4, 0, -3),
new Vector3(-2, 0, -2), new Vector3(-4, 0, -3), new Vector3(-3, 0, -2),
new Vector3(-2, 0, -2), new Vector3(-3, 0, -2), new Vector3(-2, 0, -1),
new Vector3(0, 2, -2), new Vector3(0, 0, -2), new Vector3(-2, 0, -2),
new Vector3(0, 2, -2), new Vector3(-2, 0, -2), new Vector3(-2, 2, -2),
new Vector3(-2, 2, -2), new Vector3(-2, 0, -2), new Vector3(-2, 0, -1),
new Vector3(-2, 2, -2), new Vector3(-2, 0, -1), new Vector3(-2, 2, -1),
new Vector3(-2, 1, -1), new Vector3(-2, 0, -1), new Vector3(-2, 0, 0),
new Vector3(-2, 1, -1), new Vector3(-2, 0, 0), new Vector3(-2, 1, 0),
new Vector3(-2, 1, 0), new Vector3(-2, 0, 0), new Vector3(-3, 0, 0),
new Vector3(0, 0, -3), new Vector3(0, 0, -2), new Vector3(0, 1, -2),
}; public Testing_convex() {vertices = my_verts;} }