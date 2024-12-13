using Godot;
using System;

public partial class Asteroid : CharacterBody2D
	
{
    Player player;

	[Export] float damage = 10f;
	[Export] float attackPerSecond = 2f;
    [Export] float speed = 200f;

    float attackSpeed;
	float attackTime;
	bool attackRange = false;
	public override void _Ready()
	{
		player = (Player)GetTree().Root.GetNode("Main").GetNode("Player");

		attackSpeed = 1 / attackPerSecond;
		attackTime = attackSpeed;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (attackRange && attackTime <= 0) 				
		{
			Attack();
            attackTime -= (float)delta;
        }
		else
		{
			attackTime -= (float)delta;
        }
	}
    public void Attack()
    {

    }

	public void AttackRangeBodyEnter (Node2D body)
	{
		if (body.IsInGroup("player"))
		{
			attackRange = true;
		}
	}

    public void AttackRangeBodyExit(Node2D body)
    {
        if (body.IsInGroup("player"))
        {
            attackRange = false;
			attackTime = attackSpeed;
        }
    }
}
