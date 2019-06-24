using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abilities {
	public class FireTest : MonoBehaviour
	{
		[SerializeField] private float damagePerSecond = 100;
		[SerializeField] private float lifeTime = 5;

		// private EnemyTest targetEnemy;

		private void Start() {
			Destroy(gameObject, lifeTime);
		}

		private void OnTriggerStay2D(Collider2D other) {
			if (other.gameObject.tag == "Enemy") {
				// other.GetComponent<EnemyTest>().TakeDamage(damagePerSecond * Time.deltaTime);
			}
		}
	}
}