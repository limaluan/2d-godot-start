using Godot;
using System;

public partial class Bullet : Area2D
{
	[Export]
	public float Speed { get; set; } = 1000;

	private float travelledDistance;
	private const float RANGE = 1200;
	public override void _PhysicsProcess(double delta)
	{
		var direction = Vector2.Right.Rotated(Rotation);
		Position += direction * Speed * (float)delta;

		travelledDistance += Speed * (float)delta;

		if (travelledDistance > RANGE)
		{
			QueueFree();
		}
	}

	public void OnShooted(Node2D body)
	{
		QueueFree();

		if (body.HasMethod("TakeDamage")) {
			body.Call("TakeDamage");
		}
	}
}
