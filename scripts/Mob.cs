using Godot;
using System;

public partial class Mob : CharacterBody2D
{

  private Node2D player;

  [Export]
  public int speed = 300;

  public override void _Ready()
  {
    player = GetNode<Node2D>("/root/Game/Player");
  }

  public override void _PhysicsProcess(double delta)
  {
    var direction = GlobalPosition.DirectionTo(player.GlobalPosition);
    Velocity = direction * speed;
    MoveAndSlide();
  } 
}
