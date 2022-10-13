using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private byte m_MaxPlayerPerRoom = 4;
    [SerializeField] private TMPro.TMP_InputField m_NameInputField;
    [SerializeField] private TMPro.TMP_Text m_NameInputFieldPlaceholder;
    [SerializeField] private GameObject m_UI;
    [SerializeField] private GameObject m_ProgressLabel;

    private bool isConnecting;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        m_ProgressLabel.SetActive(false);
        m_UI.SetActive(true);
    }

    public void Connect()
    {
        if (string.IsNullOrEmpty(m_NameInputField.text))
        {
            m_NameInputFieldPlaceholder.text = "Name Empty !!";
            return;
        }
        m_ProgressLabel.SetActive(true);
        m_UI.SetActive(false);
        isConnecting = true;

        PhotonNetwork.NickName = m_NameInputField.text;

        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        } else
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        if (isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        m_ProgressLabel.SetActive(false);
        m_UI.SetActive(true);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = m_MaxPlayerPerRoom });
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            PhotonNetwork.LoadLevel("DevScene");
        }
    }
}
