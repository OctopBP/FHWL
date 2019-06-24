using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(fileName = "AOE", menuName = "Ability/AOE", order = 53)]
	public class AbilityAOE: AbilityAttribute
	{
		public float areaOfEffect = 0;
	}
}
