using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

	/*
	 * CAMERA SCRIPT :
	 * 1. mouse look
	 * 2. arrow / WASD movement
	 * 3. reset position
	*/

	// mouseLook vars
	Vector2 _mouseAbsolute;
	Vector2 _smoothMouse;
	public Vector2 clampInDegrees = new Vector2(360, 180);
	public Vector2 sensitivity = new Vector2(2, 2);
	public Vector2 smoothing = new Vector2(3, 3);
	public Vector2 targetDirection;

	// move vars
	public float speedHorizont;
	public float speedMove;

	// reset vars
	Vector3 defaultCamPos;

	void Start()

	{
		targetDirection = transform.localRotation.eulerAngles;

	}

	void Update()

	{

		var x = Input.GetAxis("Horizontal") * Time.deltaTime * speedHorizont;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * speedMove;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);

		// Allow the script to clamp based on a desired target value.
		var targetOrientation = Quaternion.Euler(targetDirection);

		// Get raw mouse input for a cleaner reading on more sensitive mice.
		var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

		// Scale input against the sensitivity setting and multiply that against the smoothing value.
		mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity.x * smoothing.x, sensitivity.y * smoothing.y));

		// Interpolate mouse movement over time to apply smoothing delta.
		_smoothMouse.x = Mathf.Lerp(_smoothMouse.x, mouseDelta.x, 1f / smoothing.x);
		_smoothMouse.y = Mathf.Lerp(_smoothMouse.y, mouseDelta.y, 1f / smoothing.y);

		// Find the absolute mouse movement value from point zero.
		_mouseAbsolute += _smoothMouse;

		// Clamp and apply the local x value first, so as not to be affected by world transforms.
		if (clampInDegrees.x < 360)
			_mouseAbsolute.x = Mathf.Clamp(_mouseAbsolute.x, -clampInDegrees.x * 0.5f, clampInDegrees.x * 0.5f);

		var xRotation = Quaternion.AngleAxis(-_mouseAbsolute.y, targetOrientation * Vector3.right);
		transform.localRotation = xRotation;

		// Then clamp and apply the global y value.
		if (clampInDegrees.y < 360)
			_mouseAbsolute.y = Mathf.Clamp(_mouseAbsolute.y, -clampInDegrees.y * 0.5f, clampInDegrees.y * 0.5f);

		transform.localRotation *= targetOrientation;

		var yRotation = Quaternion.AngleAxis(_mouseAbsolute.x, transform.InverseTransformDirection(Vector3.up));
		transform.localRotation *= yRotation;

	}

	public void res() {
		this.transform.position = defaultCamPos;
	}	
}
