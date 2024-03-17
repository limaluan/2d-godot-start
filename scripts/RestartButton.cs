using Godot;
using System;

public partial class RestartButton : Sprite2D
{
  public override void _Ready()
  {
    GetTree().Paused = true;

  }
  public override void _Input(InputEvent @event)
  {
    if (@event is InputEventMouseButton)
    {
      InputEventMouseButton mouseEvent = @event as InputEventMouseButton;

      if (GetRect().HasPoint(ToLocal(mouseEvent.Position)))
      {
        GetTree().ReloadCurrentScene();
      }
    }
  }
}
