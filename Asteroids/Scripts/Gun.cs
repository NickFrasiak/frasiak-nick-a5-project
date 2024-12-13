using Godot;
using System;

public partial class Gun : Node2D
{
    [Export] PackedScene bulletScene;
    [Export] float bulletSpeed = 700f;
    [Export] float bulletDamage = 30f;
    [Export] float bulletsPerSecond = 10;

    float fireRate;
    float bulletTimer = 0f;


    public override void _Ready()
    {
        fireRate = 1 / bulletsPerSecond;
    }


    public override void _Process(double delta)
    {
        //Player shoot
        if (Input.IsActionJustPressed("shoot") && bulletTimer > fireRate)
        {
            RigidBody2D bullet = bulletScene.Instantiate<RigidBody2D>();

            bullet.Rotation = GlobalRotation;
            bullet.GlobalPosition = GlobalPosition;
            bullet.LinearVelocity = bullet.Transform.X * bulletSpeed;

            GetTree().Root.AddChild(bullet);

            bulletTimer = 0f;
        }
        else
        {
            bulletTimer += (float)delta;

        }
    }
}