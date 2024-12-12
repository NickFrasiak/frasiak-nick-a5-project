using Godot;
using System;

public partial class Player : Node2D
{
	[Export]
	public float speed = 200;
	[Export]
	public float rotationSpeed = 5;

	private Vector2 velocity = Vector2.Zero;
	public override void _Ready()
	{

	}
	public override void _Process(double delta)
	{
		//player rotation
		if (Input.IsActionPressed("right"))
		{
            Rotation += rotationSpeed * (float)delta;
        }

		if (Input.IsActionPressed("left"))
		{
            Rotation -= rotationSpeed * (float)delta;
        }

		//Movement
		if (Input.IsActionPressed("forward"))
		{
			Position += (Transform.X * speed) * (float)delta;
        }
	}

}


