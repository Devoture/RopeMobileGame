using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScale : MonoBehaviour {

	public float scaleTimer = 2.0f;
	public float scaleAmount = 3.0f;
	public bool isScaling;

	private bool canScale;
	private Vector3 originalScale;
	private IEnumerator coroutine;

	void Start() {
		originalScale = transform.localScale;
	}

	void Update() {
		if(Input.GetMouseButtonUp(0) && !isScaling) {
			coroutine = ScaleRope(scaleTimer);
			StartCoroutine(coroutine);
		}

		if(canScale) {
			transform.localScale += new Vector3(1, 0, 0) * Time.deltaTime * scaleAmount;
		}
	} 

	IEnumerator ScaleRope(float waitTime) {
		isScaling = true;
		canScale = true;
		yield return new WaitForSeconds(waitTime);
		ResetRope();
	}

	public void ResetRope() {
		StopCoroutine(coroutine);
		canScale = false;
		isScaling = false;
		transform.localScale = originalScale;
	}
}
