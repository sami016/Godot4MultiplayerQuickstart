using Godot;

namespace Multiplayer.Scenes.Game.Player;

public partial class FpsController : Node
{
    private static float MouseSensitivity = 1200;
    [Export] public CharacterBody3D Character { get; set; }
    [Export] public Camera3D Camera { get; set; }

    public override void _Ready()
    {
        Character = GetParent<CharacterBody3D>();
        Input.MouseMode = Input.MouseModeEnum.Captured;
    }

    public override void _Process(double delta)
    {
    }

    public override void _Input(InputEvent e)
    {
        if (!IsMultiplayerAuthority()) return;
        if (e is InputEventMouseMotion inputEventMouseMotion)
        {
            Camera.Rotation = new Vector3(
                Mathf.Clamp(Camera.Rotation.X - inputEventMouseMotion.Relative.Y / MouseSensitivity, Mathf.DegToRad(-89.9f), Mathf.DegToRad(89.9f)),
                Camera.Rotation.Y,
                Camera.Rotation.Z
            );

            Character.Rotation = new Vector3(
                Character.Rotation.X,
                Character.Rotation.Y - inputEventMouseMotion.Relative.X / MouseSensitivity,
                Character.Rotation.Z
            );
        }
    }
}
