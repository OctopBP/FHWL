using System.Linq;
using UnityEngine;

public class Spirit : MonoBehaviour
{
	[SerializeField, Tooltip("Радиус поиска цели пля вселения")] private float radius;

	private GameObject target;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
			if (target != null) {
				// Вселение
				target.GetComponent<Character>().SetPlayerInput();
				Camera.main.GetComponent<CameraLookAt>().SetTarget(target.gameObject);
				gameObject.SetActive(false);
			}
		}
    }

	private void FixedUpdate() {
		var colliders = Physics2D.OverlapCircleAll(transform.position, radius);

		var t = colliders
			.Where(col => col.CompareTag("Enemy"))
			.OrderBy(col => Vector3.Distance(col.transform.position, transform.position))
			.FirstOrDefault();

		if (t == null)
			target = null;
		else
			target = t.gameObject;
	}
}
