using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abilities {
	// public class FireballAbility : AbilitySlot
	// {
	// 	private GameObject bullet;

	// 	public override void OnUse() {
	// 		bullet = Instantiate(abilityData.Prefab);

	// 		var mouseOrigin = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
	// 		var mousePosition = new Vector3(mouseOrigin.x, mouseOrigin.y, 0f);
	// 		var dirrection = mousePosition - transform.position;
	// 		var bulletRotation = Quaternion.FromToRotation(abilityData.Prefab.transform.up, dirrection);

	// 		Destroy(bullet, abilityData.LifeTime);
	// 	}

	// 	public override void OnLife() {
	// 		bullet.transform.position += Vector3.forward * 5;
	// 	}

	// 	public override void OnEnd() {

	// 	}
	// }
}
