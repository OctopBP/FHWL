using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Abilities;

public class PlayerTest : MonoBehaviour
{
	[Header("Тут водим значения для способностей")]
	public List<Ability> Abilities;
	public List<AbilityGUI> AbilitiesGUI;
	private List<AbilitySlot> abilitiesSlots = new List<AbilitySlot>();

	[Header("Манна")]
	public float Mana = 500;
	public float MaxMana = 500;

	[Header("На сколько будет восстанавливаться манна в секунду")]
	public float ManaRegen = 10;

	[SerializeField] private Image manaBar;

	// [SerializeField] private DmgText manaPrefab;

	[SerializeField] private Transform shotPoint;
	

	public static PlayerTest intstance;

	private void Start() {
		intstance = this;

		for (int i = 0; i < 3; i++) {
			// var slot = new AbilitySlot(AbilitiesGUI[i], ((KeyCode) ((int) KeyCode.Alpha1) + i).GetKeyName());
			// abilitiesSlots.Add(slot);
		}

		var j = 0;
		foreach (var ability in Abilities)
		{
			abilitiesSlots[j].Init(ability);
			j++;
		}
	}

	private void Update() {

		if (Input.GetKeyDown(KeyCode.W)) {
			transform.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 5, ForceMode2D.Impulse);
		}

		var moveSpeed = .1f;
		if (Input.GetKey(KeyCode.D)) {
			transform.localScale = new Vector3(1, 1, 1);
			transform.localPosition += Vector3.right * moveSpeed;
		}
		if (Input.GetKey(KeyCode.A)) {
			transform.localScale = new Vector3(-1, 1, 1);
			transform.localPosition += Vector3.left * moveSpeed;
		}

		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			UseAbility(0);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			UseAbility(1);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			UseAbility(2);
		}

		foreach (var slot in abilitiesSlots) {
			if (slot.Unlocked)
				slot.UpdateSlot(Mana);
		}

		Mana += ManaRegen * Time.deltaTime;
		Mana = Mathf.Min(Mana, MaxMana);

		manaBar.fillAmount = Mana / MaxMana;
	}

	public void AddMana(float mana) {
		Mana += mana;
		Mana = Mathf.Min(Mana, MaxMana);

		// Mana text
		var textPos = transform.position;
		textPos.x += Random.Range(-.3f, .3f);;
		textPos.y += 1 + Random.Range(-.3f, .3f);

		// var manaText = Instantiate(manaPrefab, textPos, Quaternion.identity);
		// manaText.SetValue(mana);
	}

	private void UseAbility(int i) {
		// Если способность разблокировани
		if (abilitiesSlots[i].Unlocked) {
			// Если хватает маны
			if (Mana >= abilitiesSlots[i].abilityData.Coast) {
				// Если способность не в кд
				if (abilitiesSlots[i].ToReload <= 0) {
					abilitiesSlots[i].UseAbility(shotPoint);
					Mana -= abilitiesSlots[i].abilityData.Coast;
				}
				else {
					Debug.Log("Reload: " + abilitiesSlots[i].ToReload);
				}
			}
			else {
				Debug.Log("Not enough mana");
			}
		}
		else {
			Debug.Log("Locked");
		}
	}
}