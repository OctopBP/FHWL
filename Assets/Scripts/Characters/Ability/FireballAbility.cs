using System.Collections.Generic;
using UnityEngine;

public class FireballAbility : MonoBehaviour, IAbility
{
	private Queue<Fireball> projectilePool;
	[SerializeField] private float poolSize = 3;

	public void Init(Fireball fireball) {
		projectilePool = new Queue<Fireball>();

		for (int i = 0; i < poolSize; i++) {
			var newProjectile = Instantiate(fireball);
			projectilePool.Enqueue(newProjectile);
			newProjectile.gameObject.SetActive(false);
		}
	}

	public void OnUse() {
		var projectile = projectilePool.Dequeue();

		// Rotate
		var mouseOrigin = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
		var mousePosition = new Vector3(mouseOrigin.x, mouseOrigin.y, 0f);

		var direction = mousePosition - transform.position;

		// Переводим в углы
		var angle = Mathf.Atan(direction.y / direction.x) * Mathf.Rad2Deg;
		angle += 90 - Mathf.Sign(direction.x) * 90;

		projectile.transform.eulerAngles = new Vector3(0, 0, angle);
		projectile.transform.position = transform.position;
		
		projectile.gameObject.SetActive(true);
		projectile.OnStart();

		projectilePool.Enqueue(projectile);
	}
}
