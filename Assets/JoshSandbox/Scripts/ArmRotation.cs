using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour {

	public RopeScale scaleScript;

	void Update() {
		if(Input.GetMouseButton(0) && !scaleScript.isScaling) {
			Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 difference = mouseScreenPosition - transform.position;
			float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
		}
	}
}