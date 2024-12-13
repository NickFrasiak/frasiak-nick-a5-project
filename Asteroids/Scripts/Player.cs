using Godot;
using System;

public partial class Player : Node2D
{
    [Export] public float speed = 300;
    [Export] public float rotationSpeed = 5;

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
        else
        {
            //If not moving, moves player forward
            Position += (Transform.X * (speed * 0.5f)) * (float)delta;
        }

        //Screen Wrap
        if (Position.X < 0)
        {
            Position = new Vector2(GetViewport().GetVisibleRect().Size.X, Position.Y);
        }
        else if (Position.X > GetViewport().GetVisibleRect().Size.X)
        {
            Position = new Vector2(0, Position.Y);
        }

        if (Position.Y < 0)
        {
            Position = new Vector2(Position.X, GetViewport().GetVisibleRect().Size.Y);
        }
        else if (Position.Y > GetViewport().GetVisibleRect().Size.Y)
        {
            Position = new Vector2(Position.X, 0);
        }
    }
}


