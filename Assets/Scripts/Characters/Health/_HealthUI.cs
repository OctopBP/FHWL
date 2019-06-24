using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class _HealthUI : MonoBehaviour
{
	[SerializeField] private TMP_Text hpText;
	[SerializeField] private RectTransform hpBar;
	[SerializeField] private RectTransform hpBarWhite;

	[SerializeField] private float waitTime = 1;
	[SerializeField] private float reductionTime = 1;

	[SerializeField] private GameObject dmgTextPrefab;
	[SerializeField] private GameObject dmgTextParent;

	private HealthSystem healthSystem;

	public void Setup(HealthSystem healthSystem)
	{
		this.healthSystem = healthSystem;
		healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;

		hpText.text = healthSystem.Health.ToString();
	}

	private void HealthSystem_OnHealthChanged(object sender, System.EventArgs e)
	{
		hpBar.localScale = new Vector3(healthSystem.HealthPercent, 1, 1);
		hpText.text = healthSystem.Health.ToString();
	}

	public void ScaleWhiteHp(int whiteHp, int curHp)
	{
		StartCoroutine(WhiteHpBarScaling(whiteHp, curHp));
	}

	IEnumerator WhiteHpBarScaling(int whiteHp, int curHp) {
		yield return new WaitForSeconds(waitTime);

		float counter = reductionTime;
		while (counter >= 0)
		{
			counter -= Time.deltaTime;
			
			var curveScale = counter / reductionTime;
			var whiteScale = (curHp + ((whiteHp - curHp) * curveScale)) / healthSystem.MaxHealth;
			hpBarWhite.localScale = new Vector3(whiteScale, 1, 1);

			yield return null;
		}
	}
}
