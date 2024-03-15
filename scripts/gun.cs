using Godot;
using System;

public partial class gun : Area2D
{
    public override void _PhysicsProcess(double delta)
    {
      var enemiesInRange = GetOverlappingBodies();

      if (enemiesInRange.Count > 0) {
        LookAt(enemiesInRange[0].GlobalPosition);
      }
    }
}
