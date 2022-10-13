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

    [SerializeField] private GameObject m_TPSCameraRig;

    [SerializeField] private GameObject m_VirusCamerRig;

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
            if (photonView.IsMine)
                ActiveCameraRig();

            Vector3 initialPos = UserDeviceManager.GetDeviceUsed() == UserDeviceType.HTC ? new Vector3(0f, 0f, 0f) : new Vector3(0f, 5f, 0f);
            PhotonNetwork.Instantiate("Prefabs/" + playerPrefab.name, initialPos, Quaternion.identity, 0);
        }
    }

    private void ActiveCameraRig()
    {
        string deviceUsed = AppConfig.Inst.DeviceUsed.ToLower();
        
        if (deviceUsed == "htc" && UnityEngine.XR.XRSettings.isDeviceActive || deviceUsed == "auto" && UnityEngine.XR.XRSettings.isDeviceActive)
        {
            m_TPSCameraRig.SetActive(false);
            m_VirusCamerRig.SetActive(false);
        } else
        {
            m_TPSCameraRig.SetActive(true);
            m_VirusCamerRig.SetActive(true);
        }
    }
}
