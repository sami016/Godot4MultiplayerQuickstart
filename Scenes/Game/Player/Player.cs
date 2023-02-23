using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Multiplayer.Scenes.Game.Player;

public partial class Player : CharacterBody3D
{
    private Label3D _label;

    private string _playerName;
    [Export] public string PlayerName
    {
        get => _playerName;
        set
        {
            _playerName = value;
            if (_label != null)
            {
                _label.Text = value;
            }
        }
    }

    public override void _EnterTree()
    {
        if (int.TryParse(Name.ToString().Replace("player_", ""), out var peerId))
        {
            SetMultiplayerAuthority(peerId);
        }
    }

    public override void _Ready()
    {
        _label = GetNode<Label3D>("./player_name");
        var camera = GetNode<Camera3D>("./camera");
        camera.Current = IsMultiplayerAuthority();
        if (IsMultiplayerAuthority())
        {
            PlayerName = System.Environment.UserName
                ?? "Player";
            _label.Visible = false;
        }
    }

}
