using Godot;
using Multiplayer.Scenes.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplayer.Scenes.Game;

public partial class ClientMode : Node
{
    public override void _Ready()
    {
        AddChild(new Client());
    }
}
