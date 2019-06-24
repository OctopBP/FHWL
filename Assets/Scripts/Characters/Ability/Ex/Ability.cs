using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abilities
{
    public enum ShootType {
        OneShoot,
        Rifle
    }
	
	[System.Serializable]
	public struct AttributeStruct {
		public AbilityAttribute Attribute;
		public float Value;
	}

    [CreateAssetMenu(fileName = "Ability", menuName = "Ability/Ability", order = 52)]
    public class Ability : ScriptableObject {
        [SerializeField] public string abilityName = "AbilityName";
		[SerializeField, Multiline] public string description = "";
        [SerializeField] private Sprite icon;

        [SerializeField] private float reloadTime = 1;

        [SerializeField] private float lifeTime = 1;
        [SerializeField] private int coast = 100;

        [SerializeField] private GameObject prefab;
        [SerializeField] private ShootType shootType;
		
        [SerializeField] private bool moveWithPlayer = false;

        [SerializeField] private List<AttributeStruct> attributes = new List<AttributeStruct>();

		public string AbilityName => abilityName;
        public string Description => description;
        public Sprite Icon => icon;
        
        public float ReloadTime => reloadTime;
        
        public float LifeTime => lifeTime;
        public int Coast => coast;
        
        public GameObject Prefab => prefab;
        public ShootType ShootType => shootType;

        public bool MoveWithPlayer => moveWithPlayer;
    }
}