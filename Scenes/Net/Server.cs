using Godot;
using Multiplayer.Scenes.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplayer.Scenes.Net;

public partial class Server : Node
{
	private readonly WebSocketMultiplayerPeer _peer;
    private readonly PeerConnected _peerConnected;
    private readonly PeerDisconnected _peerDisconnected;

    public Server(PeerConnected peerConnected, PeerDisconnected peerDisconnected)
	{
		_peer = new WebSocketMultiplayerPeer();

        _peerConnected = peerConnected;
        _peerDisconnected = peerDisconnected;
    }

    public override void _Ready()
    {
        Multiplayer.PeerConnected += PeerConnected;
        Multiplayer.PeerDisconnected += PeerDisconnected;
        Start();
    }

    private void Start()
	{
        Multiplayer.MultiplayerPeer = null;
        _peer.CreateServer(5678);
        Multiplayer.MultiplayerPeer = _peer;

        GD.Print("server started");
    }

    private void PeerConnected(long id)
    {
        _peerConnected.Handle(id);
    }

    private void PeerDisconnected(long id)
    {
        _peerDisconnected.Handle(id);
    }
}
