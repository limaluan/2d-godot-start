using Godot;
using System;

public partial class Gun : Area2D
{

  private PackedScene _bullet;
  private Marker2D _shootingPoint;
  private Godot.Collections.Array<Node2D> enemiesInRange;

  public override void _Ready()
  {
    _bullet = GD.Load<PackedScene>("res://bullet.tscn");
    _shootingPoint = GetNode<Marker2D>("%ShootingPoint");
  }

  public override void _PhysicsProcess(double delta)
  {
    enemiesInRange = GetOverlappingBodies();

    if (enemiesInRange.Count > 0)
    {
      LookAt(enemiesInRange[0].GlobalPosition);
    }
  }

  public void Shoot()
  {
    Bullet newBullet = (Bullet)_bullet.Instantiate();
    newBullet.GlobalPosition = _shootingPoint.GlobalPosition;
    newBullet.GlobalRotation = _shootingPoint.GlobalRotation;
    _shootingPoint.AddChild(newBullet);
  }

  public void OnTimerTimeOut()
  {
    if (enemiesInRange.Count > 0)
    {
      Shoot();
    }
  }
}
