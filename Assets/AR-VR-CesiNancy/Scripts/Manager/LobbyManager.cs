using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbyManager : MonoBehaviourPunCallbacks
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
    public override void OnJoinedLobby()
    {
        roomItemsList.Clear();
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("DevScene");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomList(roomList);
    }

    public override void OnLeftLobby()
    {
        roomItemsList.Clear();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        roomItemsList.Clear();
    }

    private void UpdateRoomList(List<RoomInfo> list)
    {
        foreach (RoomInfo info in list)
        {
            if (info.RemovedFromList)
            {
                foreach (RoomItem item in roomItemsList)
                {
                    if (item.m_RoomName.text == info.Name)
                    {
                        roomItemsList.Remove(item);
                        Destroy(item.gameObject);
                        break;
                    }
                } 
            }
            else
            {
                RoomItem newRoom = Instantiate(roomItemPrefab, m_ContentObject);
                newRoom.SetRoomInfo(info);
                roomItemsList.Add(newRoom);
            }
        }
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }
}