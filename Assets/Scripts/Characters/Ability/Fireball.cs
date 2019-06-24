using UnityEngine;
using System.Collections.Generic;

public class Fireball : MonoBehaviour, IProjectile
{
	[SerializeField] private float speed;
	[SerializeField] private int damage;
	[SerializeField] private float damageRange;

	private void Update() {
		OnLifetime();
	}

	public void OnStart() { }

	public void OnLifetime() {
		transform.position += transform.right * speed * Time.deltaTime;
	}

	public void OnEnd() {
		var colliders = Physics2D.OverlapCircleAll(transform.position, damageRange);

		foreach (var col in colliders) {
			if (col.CompareTag("Enemy")) {
				col.gameObject.GetComponent<Character>().Health.TakeDamage(damage);
			}
		}

		gameObject.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player"))
			return;

		OnEnd();
	}
}