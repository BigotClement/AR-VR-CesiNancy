using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbyPCManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField m_CreateRoomInput;
    [SerializeField] private byte m_MaxPlayerPerRoom = 4;

    [SerializeField] private RoomItem roomItemPrefab;
    [SerializeField] private Transform m_ContentObject;

    private List<RoomItem> roomItemsList = new List<RoomItem>();

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    public void CreateRoom()
    {
        if (!string.IsNullOrEmpty(m_CreateRoomInput.text))
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = m_MaxPlayerPerRoom;
            roomOptions.IsVisible = true;
            roomOptions.IsOpen = true;

            PhotonNetwork.CreateRoom(m_CreateRoomInput.text, roomOptions, TypedLobby.Default);
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("DevScene");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomList(roomList);
    }

    private void UpdateRoomList(List<RoomInfo> list)
    {
        foreach (RoomItem item in roomItemsList)
        {
            Destroy(item.gameObject);
        }
        roomItemsList.Clear();

        foreach (RoomInfo info in list)
        {
            RoomItem newRoom = Instantiate(roomItemPrefab, m_ContentObject);
            newRoom.SetRoomInfo(info);
            roomItemsList.Add(newRoom);
            
        }
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }
}