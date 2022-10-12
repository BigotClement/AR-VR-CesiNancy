using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public static NetworkManager Instance;
    [SerializeField] private GameObject playerPrefabPC;
    [SerializeField] private GameObject playerPrefabVR;

    [SerializeField] private GameObject m_FreeLookCameraRig;
    [SerializeField] private GameObject m_PlayerFollowVirtualCamera;

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    private void Start()
    {
        Instance = this;

        GameObject playerPrefab = UserDeviceManager.GetPrefabToSpawnWithDeviceUsed(playerPrefabPC, playerPrefabVR);

        if (playerPrefab != null && UserManager.UserMeInstance == null)
        {
            ActiveCameraRig();
            Vector3 initialPos = UserDeviceManager.GetDeviceUsed() == UserDeviceType.HTC ? new Vector3(0f, 0f, 0f) : new Vector3(0f, 5f, 0f);
            PhotonNetwork.Instantiate("Prefabs/" + playerPrefab.name, initialPos, Quaternion.identity, 0);
        }
    }

    private void ActiveCameraRig()
    {
        string deviceUsed = AppConfig.Inst.DeviceUsed.ToLower();
        
        if (deviceUsed == "htc" && UnityEngine.XR.XRSettings.isDeviceActive)
        {
            m_FreeLookCameraRig.SetActive(false);
            m_PlayerFollowVirtualCamera.SetActive(false);
        } else
        {
            m_FreeLookCameraRig.SetActive(true);
            m_PlayerFollowVirtualCamera.SetActive(true);
        }
    }
}
