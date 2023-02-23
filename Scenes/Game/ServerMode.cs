using Godot;
using Multiplayer.Scenes.Net;

namespace Multiplayer.Scenes.Game;

public partial class ServerMode : Node
{
    public override void _Ready()
    {
        var world = GetNode("../world");
        var peerConnected = new PeerConnected(world);
        var peerDisconnected = new PeerDisconnected(world);
        AddChild(new Server(peerConnected, peerDisconnected));
        peerConnected.Handle(1);
    }
}
