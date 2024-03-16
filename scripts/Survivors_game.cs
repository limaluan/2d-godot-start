using Godot;
using Enemies;
using System;

public partial class Survivors_game : Node2D
{

	private PackedScene _mob;
	private PathFollow2D _pathFollow2d;

	public override void _Ready()
	{
		_mob = GD.Load<PackedScene>("res://mob.tscn");
		_pathFollow2d = GetNode<PathFollow2D>("%PathFollow2D");
	}

	public void SpawnSlime()
	{
		Node2D newMob = (Node2D)_mob.Instantiate();
		_pathFollow2d.ProgressRatio = GD.Randf();
		newMob.GlobalPosition = _pathFollow2d.GlobalPosition;
		AddChild(newMob);
		GD.Print("Spawnou");
	}

	public void OnTimerSpawnSlimeTimeOut()
	{
		SpawnSlime();
	}
}
