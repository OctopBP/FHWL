using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(fileName = "Damage", menuName = "Ability/Damage", order = 54)]
	public class AbilityDamage: AbilityAttribute
	{
		public float damage = 0;
	}
}
