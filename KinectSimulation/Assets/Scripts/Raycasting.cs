using UnityEngine;
using System.Collections;
using System.IO;

public class Raycasting : MonoBehaviour {

	public string filename;
	public float maxheight;

	public Ray ray;

	private StreamWriter file;

	// Use this for initialization
	void Start () {
		file = File.CreateText (filename);
		captureTilHeight (maxheight);
		file.Close ();
	}

	//Note trabajando en radianes

	private void rotateToRight(RaycastHit hit){

		float maxAngle = (57f / 2f) * Mathf.Deg2Rad;
		float step = 0.1f * Mathf.Deg2Rad;
		float currentAngle = step;
		Vector3 direction;

		while (currentAngle < maxAngle) {
			direction = new Vector3 (
				Mathf.Sin (currentAngle),
				0,
				Mathf.Cos (currentAngle)
			);

			ray.direction = direction;
			Physics.Raycast (ray, out hit);
			Debug.Log (hit.point.ToString());
			file.WriteLine (hit.point.x.ToString() + "," + hit.point.y.ToString() + "," + hit.point.z.ToString() );
			currentAngle += step;
		}

	}

	private void rotateToLeft(RaycastHit hit){

		float maxAngle = (57f / 2f) * Mathf.Deg2Rad;
		float step = 0.1f * Mathf.Deg2Rad;
		float currentAngle = step;
		Vector3 direction;

		while (currentAngle > maxAngle) {
			direction = new Vector3 (
				Mathf.Sin (currentAngle),
				0,
				Mathf.Cos (currentAngle)
			);

			ray.direction = direction;
			Physics.Raycast (ray, out hit);
			Debug.Log (hit.point.ToString());
			file.WriteLine (hit.point.x.ToString() + "," + hit.point.y.ToString() + "," + hit.point.z.ToString() );
			currentAngle -= step;
		}

	}

	private void captureTilHeight(float maxHeight){

		RaycastHit hit;

		while (transform.position.y < maxHeight) {
			ray = new Ray (transform.position, transform.forward);

			if (Physics.Raycast (ray, out hit)) {
				Debug.Log (hit.point.ToString ());
				file.WriteLine (hit.point.x.ToString() + "," + hit.point.y.ToString() + "," + hit.point.z.ToString() );
			}
			rotateToRight (hit);
			rotateToLeft (hit);

			transform.position += Vector3.up *0.1f;
		}
	}

}
