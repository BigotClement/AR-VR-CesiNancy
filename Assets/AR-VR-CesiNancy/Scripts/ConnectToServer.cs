using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        string deviceUsed = AppConfig.Inst.DeviceUsed.ToLower();

        if (deviceUsed == "htc" && UnityEngine.XR.XRSettings.isDeviceActive || deviceUsed == "auto" && UnityEngine.XR.XRSettings.isDeviceActive)
        {
            SceneManager.LoadScene("LobbyVRScene");
        }
        else
        {
            SceneManager.LoadScene("LobbyPCScene");
        }
        
    }
}
