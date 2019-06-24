using System;

public interface IHealth {
	int Health { get; }
	int MaxHealth { get; }
	float HealthPercent { get; }
	
	event EventHandler OnHealthChanged;

	void TakeDamage(int amount);
	void TakeHeal(int amount);
}