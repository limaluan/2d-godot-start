using Godot;
using System;

namespace Enemies
{
  public partial class SlimeMob : CharacterBody2D
  {
    private Node2D _player;
    private int _health = 3;
    private Node _slime;
    private PackedScene _smokeScene;

    [Export]
    public int speed = 300;

    public override void _Ready()
    {
      _player = GetNode<Node2D>("/root/Game/Player");
      _slime = GetNode("./Slime");
      _smokeScene = GD.Load<PackedScene>("res://smoke_explosion/smoke_explosion.tscn");

      _slime.Call("play_walk");
    }

    public override void _PhysicsProcess(double delta)
    {
      var direction = GlobalPosition.DirectionTo(_player.GlobalPosition);
      Velocity = direction * speed;
      MoveAndSlide();
    }

    public void TakeDamage()
    {
      _slime.Call("play_hurt");
      _health -= 1;

      if (_health <= 0)
      {
        QueueFree();
        Node2D newSmoke = (Node2D)_smokeScene.Instantiate();
        newSmoke.GlobalPosition = GlobalPosition;
        GetParent().AddChild(newSmoke);
      }
    }
  }
}