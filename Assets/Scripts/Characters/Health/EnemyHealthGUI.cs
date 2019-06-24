using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthGUI : MonoBehaviour, IHealthGUI
{
	[SerializeField] private Image hpBar;
	
	private IHealth health;

	public void Setup(IHealth health) {
		this.health = health;
		this.health.OnHealthChanged += OnHealthChanges;
	}

	public void OnHealthChanges(object sender, System.EventArgs e) {
		hpBar.fillAmount = health.HealthPercent;
	}
}
