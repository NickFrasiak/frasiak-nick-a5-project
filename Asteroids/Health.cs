using Godot;
using System;

public partial class Health : Node2D
{
	[Export] public float maxHealth = 100f;
	float health;
	public override void _Ready()
	{
		health = maxHealth;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void Damage(float damage)
	{
		health -= damage;

		if (health >= 0)
		{
			GetParent().QueueFree();
		}
	}
}
