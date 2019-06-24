using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abilities {
	public class FireballTest : MonoBehaviour
	{
		[SerializeField] private float damage = 100;
		[SerializeField] private float range;
		[SerializeField] private GameObject expl;

		private void Start() {
			Destroy(gameObject, 5);

			var mouseOrigin = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
			var mousePosition = new Vector3(mouseOrigin.x, mouseOrigin.y, 0f);

			var direction = mousePosition - transform.position;

			// Переводим в углы
			var angle = Mathf.Atan(direction.y / direction.x) * Mathf.Rad2Deg;
			angle += 90 - Mathf.Sign(direction.x) * 90;

			transform.eulerAngles = new Vector3(0, 0, angle);
		}

		private void Update() {
			transform.position += transform.right * 10 * Time.deltaTime;
		}

		private void OnTriggerEnter2D(Collider2D other) {
			if (other.gameObject.tag == "Player")
				return;

			var explPos = transform.position;
			explPos.y += 0.5f;

			var e = Instantiate(expl, explPos, Quaternion.identity);
			Destroy(e, 1);

			Detonate();
		}

		public void Detonate() {
			var colliders = Physics2D.OverlapCircleAll(transform.position, range);

			foreach (var collider in colliders) {
				if (collider.gameObject.tag == "Enemy") {
					// collider.gameObject.GetComponent<EnemyTest>().TakeDamage(damage);
				}
			}
			
			Destroy(gameObject);
		}
	}
}