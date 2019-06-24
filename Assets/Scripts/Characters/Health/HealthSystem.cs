using System;
using UnityEngine;

public class HealthSystem : IHealth
{
	private int health;
	private int maxHealth;

	public int Health => health;
	public int MaxHealth => maxHealth;
	
	public float HealthPercent => (float) health / maxHealth;

	public event EventHandler OnHealthChanged;



	public HealthSystem(int maxHealth) {
		this.maxHealth = maxHealth;
		health = maxHealth;
	}



	public void TakeDamage(int amount) {
		health = Mathf.Max(0, health - amount);

		if (OnHealthChanged != null)
			OnHealthChanged(this, EventArgs.Empty);
	}

	public void TakeHeal(int amount) {
		health = Mathf.Min(maxHealth, health + amount);
		
		if (OnHealthChanged != null)
			OnHealthChanged(this, EventArgs.Empty);
	}
}
