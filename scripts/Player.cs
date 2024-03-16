using Godot;
using System;

namespace Player
{
	public partial class Player : CharacterBody2D
	{
		[Signal]
		public delegate void HealthDepletedEventHandler();
		public float _health = 100.0F;

		[Export]
		public int Speed { get; set; } = 400;

		[Export]
		public float DamageRate { get; set; } = 5.0F;

		public void GetInput()
		{
			Vector2 inputDirection = Input.GetVector("move_left", "move_right", "move_up", "move_down");
			Velocity = inputDirection * Speed;
		}
		public override void _PhysicsProcess(double delta)
		{
			GetInput();
			MoveAndSlide();

			if (Velocity.Length() > 0)
			{
				GetNode("./HappyBoo").Call("play_walk_animation");
			}
			else
			{
				GetNode("./HappyBoo").Call("play_idle_animation");
			}

			var overlapingMobs = GetNode<Area2D>("%HurtBox").GetOverlappingBodies();
			if (overlapingMobs.Count > 0)
			{
				_health -= DamageRate * overlapingMobs.Count * (float)delta;
				GetNode<ProgressBar>("%ProgressBar").Value = _health;
				if (_health <= 0.0F)
				{
					EmitSignal(SignalName.HealthDepleted);
				}
			}
		}

	}
}