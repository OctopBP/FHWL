using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abilities {
	public class ManadrainTest : MonoBehaviour
	{
		[SerializeField] private float manaPerSecond = 30;
		[SerializeField] private float damagePerSecond = 15;
		[SerializeField] private float range;
		[SerializeField] private float lifeTime = 5;

		[SerializeField] private Transform startPosition;
		[SerializeField] private float scaleFactor = 0.65f;

		// private EnemyTest nearestEnemy;

		private void Start() {
			Destroy(gameObject, lifeTime);

			var colliders = Physics2D.OverlapCircleAll(transform.position, range);

			var nearestEnamyId = -1;
			var minDistance = range + 1;
			var i = 0;
			foreach (var collider in colliders) {
				if (collider.gameObject.tag == "Enemy") {
					var distance = Mathf.Abs(Vector3.Distance(collider.gameObject.transform.position, transform.position));

					if (minDistance > distance) {
						minDistance = distance;
						nearestEnamyId = i;
					}
				}
				i++;
			}
			
			if (nearestEnamyId != -1) {
				// nearestEnemy = colliders[nearestEnamyId].gameObject.GetComponent<EnemyTest>();

				var endPosition = colliders[nearestEnamyId].transform.position;
				var distance = (endPosition.x - startPosition.position.x) / scaleFactor;
				startPosition.localScale = new Vector3(distance, 1, 1);
			}
			else {
				Destroy(gameObject);
			}
		}

		private void Update() {
			// if (nearestEnemy != null) {
				// PlayerTest.intstance.AddMana(manaPerSecond * Time.deltaTime);
				// nearestEnemy.TakeDamage(damagePerSecond * Time.deltaTime);
			// }
			// else {
			// 	Destroy(gameObject);
			// }
		}
	}
}