using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplayer.Scenes.Net;

public partial class Client : Node
{
    private readonly WebSocketMultiplayerPeer _peer;

    public Client()
    {
        _peer = new WebSocketMultiplayerPeer();
    }

    public override void _Ready()
    {
        Multiplayer.ConnectedToServer += OnConnectedToServer;
        Multiplayer.ConnectionFailed += OnConnectionFailed;
        Multiplayer.ServerDisconnected += OnServerDisconnected;
        StartConnection();
    }

    private void StartConnection()
    {
        Multiplayer.MultiplayerPeer = null;
        _peer.CreateClient("ws://localhost:5678");
        Multiplayer.MultiplayerPeer = _peer;
        GD.Print("connecting");
    }

    private void OnConnectedToServer()
    {
        GD.Print("OnConnectedToServer");
    }

    private void OnConnectionFailed()
    {
        GD.Print("OnConnectionFailed");
    }

    private void OnServerDisconnected()
    {
        GD.Print("OnServerDisconnected");
    }
}
