using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;

public class UserManager : MonoBehaviourPunCallbacks
{
    public static GameObject UserMeInstance;
    private GameObject playerFollowVirtualCamera;
    [SerializeField] private Transform m_PlayerCameraRoot;

    private void Awake()
    {
        if (photonView.IsMine)
        {
            UserMeInstance = gameObject;
        }
    }

    private void Start()
    {
        updateGoFreeLookCameraRig();
        followLocalPlayer();
    }

    protected void updateGoFreeLookCameraRig()
    {
        if (!photonView.IsMine) return;
        try
        {
            Debug.Log("Find Virtual Camera");
            
            playerFollowVirtualCamera = GameObject.Find("PlayerFollowVirtualCamera");
            Debug.Log(playerFollowVirtualCamera);
        }
        catch (System.Exception ex)
        {
            Debug.LogWarning("Warning, no goFreeLookCameraRig found\n" + ex);
        }
    }

    private void followLocalPlayer()
    {
        Debug.Log(photonView.IsMine);
        Debug.Log(playerFollowVirtualCamera);

        if (photonView.IsMine && playerFollowVirtualCamera != null)
        {
            playerFollowVirtualCamera.GetComponent<CinemachineVirtualCamera>().Follow = m_PlayerCameraRoot;
        }
    }
}
