using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomItem : MonoBehaviour
{
    [SerializeField] private TMP_Text m_RoomName;
    [SerializeField] private TMP_Text m_PlayerCount;

    LobbyPCManager lobby;

    private void Start()
    {
        lobby = FindObjectOfType<LobbyPCManager>();
    }

    public void SetRoomInfo(RoomInfo info)
    {
        m_RoomName.text = info.Name;
        m_PlayerCount.text = info.PlayerCount + "/" + info.MaxPlayers;
    }

    public void JoinRoomClick()
    {
        lobby.JoinRoom(m_RoomName.text);
    }
}