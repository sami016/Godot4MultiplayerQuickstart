using Godot;
using System;

namespace Multiplayer.Scenes.Game.Player;

public partial class MovementController : Node
{
    [Export] public Camera3D Camera { get; set; }

    public const float Speed = 5.0f;
    public const float JumpVelocity = 7.5f;

    public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();

    private CharacterBody3D _character;
    //private Node3D _camera;

    public override void _Ready()
    {
        _character = GetParent<CharacterBody3D>();
        if (Camera == null) {
            throw new Exception("Camera was not defined for move controller");
        }
        //_camera = HasNode("../XROrigin3D/camera")
        //    ? GetNode<Node3D>("../XROrigin3D/camera")
        //    : GetNode<Node3D>("../camera");
    }

    public override void _PhysicsProcess(double delta)
    {
        if (!IsMultiplayerAuthority()) return;

        Vector3 velocity = _character.Velocity;

        // Add the gravity.
        //if (!_character.IsOnFloor())
        //    velocity.Y -= gravity * (float)delta;

        // Handle Jump.
        if (Input.IsActionJustPressed("ui_accept") && _character.IsOnFloor())
            velocity.Y = JumpVelocity;

        var direction = MoveForwardDirection;
        if (direction != Vector3.Zero)
        {
            velocity.X = direction.X * Speed;
            velocity.Z = direction.Z * Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(_character.Velocity.X, 0, Speed);
            velocity.Z = Mathf.MoveToward(_character.Velocity.Z, 0, Speed);
        }

        _character.Velocity = velocity;
        _character.MoveAndSlide();
    }

    private Vector3 MoveForwardDirection
    {
        get
        {
            Vector2 inputDir = Input.GetVector("move_left", "move_right", "move_up", "move_down");
            Vector3 direction = (_character.Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y));
            direction.Y = 0;
            return direction.Normalized();
        }
    }
}
