using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 400;
  
	private void GetInput() {
		Vector2 inputDirection = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		Velocity = inputDirection * Speed;
		GD.Print(Velocity);
	}
  public override void _PhysicsProcess(double delta)
  {
		GetInput();
		MoveAndSlide();	
		
		if (Velocity.Length() > 0) {
			GetNode("./HappyBoo").Call("play_walk_animation");
		} else {
			GetNode("./HappyBoo").Call("play_idle_animation");
		}
  }

}
