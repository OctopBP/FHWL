using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abilities
{
    public class AbilitySlot: MonoBehaviour {
        public Ability abilityData;
        private AbilityGUI abilityGUI;

        private float toReload;
        public float ToReload => toReload;

        public bool Unlocked;

        private string hotkeyName;

		public AbilitySlot(AbilityGUI gui, string hotkeyName) {
			abilityGUI = gui;
			this.hotkeyName = hotkeyName;
			Unlocked = false;
			abilityGUI.gameObject.SetActive(false);
		}

		public void Init(Ability ability) {
			abilityData = ability;
			Unlocked = true;

			abilityGUI.gameObject.SetActive(true);
			abilityGUI.Setup(abilityData.Icon, hotkeyName, abilityData.Coast);
		}

        public void UpdateSlot(float mana) {
            toReload = (toReload > 0) ? toReload -= Time.deltaTime : 0;

			abilityGUI.UpdateGUI(abilityData.ReloadTime, toReload, mana >= abilityData.Coast);
        }

        public void UseAbility(Transform shotPoint) {
			if(toReload <= 0)
			{	
				Debug.Log("Use ability " + abilityData.AbilityName);
				toReload = abilityData.ReloadTime;

				Instantiate(abilityData.Prefab, shotPoint.position, Quaternion.identity, (abilityData.MoveWithPlayer) ? shotPoint : null);

				// OnUse();
			}
        }

		// // При использовании
		// public virtual void OnUse() { }

		// // Пока спостобность активна
		// public virtual void OnLife() { }

		// // В конце действия
		// public virtual void OnEnd() { }
    }
}