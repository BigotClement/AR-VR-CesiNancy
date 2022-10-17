using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;

public class NetworkVirus : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform m_Head;
    [SerializeField] private Transform m_LeftHand;
    [SerializeField] private Transform m_RightHand;

    private Transform PlayerHead;
    private Transform PlayerLeftHand;
    private Transform PlayerRightHand;

    private void Start()
    {
        GameObject VirusCameraRig = GameObject.FindGameObjectWithTag("VirusCameraRig");

        PlayerHead = VirusCameraRig.transform.Find("VRCamera");
        PlayerLeftHand = VirusCameraRig.transform.Find("LeftHand");
        PlayerRightHand = VirusCameraRig.transform.Find("RightHand");
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            m_Head.gameObject.SetActive(false);
            m_LeftHand.gameObject.SetActive(false);
            m_RightHand.gameObject.SetActive(false);

            SyncVirusPlayer(m_Head, PlayerHead);
            SyncVirusPlayer(m_LeftHand, PlayerLeftHand);
            SyncVirusPlayer(m_RightHand, PlayerRightHand);
        }
    }

    private void SyncVirusPlayer(Transform target, Transform playerDevice)
    {
        target.position = playerDevice.position;
        target.rotation = playerDevice.rotation;
    }
}
