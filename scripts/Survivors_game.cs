using Godot;
using System;

public partial class Survivors_game : Node2D
{
	private PackedScene _mob;
	private PathFollow2D _pathFollow2d;
	private PackedScene _tree;
	private PackedScene _gameOverScreen;

	public override void _Ready()
	{
		_mob = GD.Load<PackedScene>("res://mob.tscn");
		_tree = GD.Load<PackedScene>("res://pine_tree.tscn");
		_gameOverScreen = GD.Load<PackedScene>("res://game_over.tscn");
		_pathFollow2d = GetNode<PathFollow2D>("%PathFollow2D");
		GetTree().Paused = false;
	}

	public void SpawnSlime()
	{
		Node2D newMob = (Node2D)_mob.Instantiate();
		_pathFollow2d.ProgressRatio = GD.Randf();
		newMob.GlobalPosition = _pathFollow2d.GlobalPosition;
		AddChild(newMob);
	}

	public void SpawnTree()
	{
		Node2D newTree = (Node2D)_tree.Instantiate();
		_pathFollow2d.ProgressRatio = GD.Randf();
		newTree.GlobalPosition = _pathFollow2d.GlobalPosition;
		AddChild(newTree);
	}

	public void OnTimerSpawnTreeTimeOut()
	{
		SpawnTree();
	}

	public void OnTimerSpawnSlimeTimeOut()
	{
		SpawnSlime();
	}

	public void OnPlayerHealthDepleted()
	{
		Node newGameOverScreen = _gameOverScreen.Instantiate();
		AddChild(newGameOverScreen);
	}
}
