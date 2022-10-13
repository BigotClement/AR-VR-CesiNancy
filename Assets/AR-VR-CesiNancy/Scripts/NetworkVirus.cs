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

    private GameObject PlayerHead;
    private GameObject PlayerLeftHand;
    private GameObject PlayerRightHand;

    private void Start()
    {
        PlayerHead = GameObject.FindGameObjectWithTag("MainCamera");
        PlayerLeftHand = GameObject.FindGameObjectWithTag("LeftHand");
        PlayerRightHand = GameObject.FindGameObjectWithTag("RightHand");
        Debug.Log(PlayerHead);
        Debug.Log(PlayerLeftHand);
        Debug.Log(PlayerRightHand);
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            m_Head.gameObject.SetActive(false);
            m_LeftHand.gameObject.SetActive(false);
            m_RightHand.gameObject.SetActive(false);

            /*InputDevices.GetDeviceAtXRNode(XRNode.Head).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
            Debug.Log(position);*/

            SyncVirusPlayer(m_Head, PlayerHead);
            SyncVirusPlayer(m_LeftHand, PlayerLeftHand);
            SyncVirusPlayer(m_RightHand, PlayerRightHand);
        }
    }

    private void SyncVirusPlayer(Transform target, GameObject playerDevice)
    {
        target.position = playerDevice.transform.position;
        target.rotation = playerDevice.transform.rotation;
    }
}
