using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
	[SerializeField] Transform target;
	[SerializeField] Vector2 offset;
	[SerializeField, Range(0, 1)] float delay;

	private void Start() {
		// EventManager.Instance.GoingIn += NewTarget;
	}

    private void Update() {
		var newPos = new Vector3(
			target.position.x + offset.x,
			target.position.y + offset.y,
			-10
		);
        transform.position = Vector3.Lerp(transform.position, newPos, 1 - delay);
    }

	public void SetTarget(GameObject newTarget) {
		target = newTarget.transform;
	}
}