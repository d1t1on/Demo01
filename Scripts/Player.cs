﻿using Godot;
using System;

public partial class Player : Area2D
{
    [Export]
    public int Speed { get; set; } = 400;

    public Vector2 ScreenSize;

    [Signal]
    public delegate void EnterEventHandler();


    public override void _Ready()
	{
        ScreenSize = GetViewportRect().Size;
    }

	public override void _Process(double delta)
	{
        Vector2 velocity = Vector2.Zero; // The player's movement vector.

        if (Input.IsActionPressed("move_right"))
            velocity.X += 1;
        if (Input.IsActionPressed("move_left"))
            velocity.X -= 1;
        if (Input.IsActionPressed("move_down"))
            velocity.Y += 1;
        if (Input.IsActionPressed("move_up"))
            velocity.Y -= 1;


        if (velocity.Length() > 0)
        {
            velocity = velocity.Normalized() * Speed;
            // 动画
            //AnimatedSprite2D animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
            //animatedSprite2D.Play();
        }
        else
        {
            //animatedSprite2D.Stop();
        }

        Position += velocity * (float)delta;
        Position = new Vector2(
            x: Mathf.Clamp(Position.X, 0, ScreenSize.X),
            y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
        );
    }

    public void EnterRotate(Node2D body)
    {
        GD.Print("EnterRotate");
    }

    public void EnterMirror(Node2D body)
    {
        GD.Print("EnterMirror");
    }

    public void EnterPartMove(Node2D body)
    {
        GD.Print("EnterPartMove");
    }
    public void EnterShop(Node2D body)
    {
        GD.Print("EnterShop");
    }
}
