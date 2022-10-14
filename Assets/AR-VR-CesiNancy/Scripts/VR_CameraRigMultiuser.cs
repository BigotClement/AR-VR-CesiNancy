using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class VR_CameraRigMultiuser : MonoBehaviourPunCallbacks
{

    [SerializeField] private GameObject SteamVRLeft, SteamVRRight, SteamVRCamera;
    //[SerializeField] private GameObject UserOtherLeftHandModel, UserOtherRightHandModel;
    [SerializeField] private GameObject teleportingPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateTeleporting();
        steamVRactivation();
    }

    private void InstantiateTeleporting()
    {
        if (photonView.IsMine)
        {
            Instantiate(teleportingPrefab);
            GameObject floor = GameObject.FindGameObjectWithTag("Floor");
            floor.transform.Find("TeleportFloor").gameObject.SetActive(true);
        }
    }

    protected void steamVRactivation()
    {
        // client execution for ALL

        // Left activation if UserMe, deactivation if UserOther
        //SteamVRLeft.GetComponent<SteamVR_Behaviour_Pose>().enabled = photonView.IsMine;

        // Left SteamVR_RenderModel activation if UserMe, deactivation if UserOther
        //SteamVRLeft.GetComponentInChildren<SteamVR_RenderModel>().enabled = photonView.IsMine;
        //SteamVRLeft.transform.Find("Model").gameObject.SetActive(photonView.IsMine);
        //SteamVRLeft.GetComponent<Hand>().enabled = photonView.IsMine;
        //SteamVRLeft.GetComponent<HandPhysics>().enabled = photonView.IsMine;

        // Right activation if UserMe, deactivation if UserOther
        //SteamVRRight.GetComponent<SteamVR_Behaviour_Pose>().enabled = photonView.IsMine;

        // Left SteamVR_RenderModel activation if UserMe, deactivation if UserOther
        //SteamVRRight.GetComponentInChildren<SteamVR_RenderModel>().enabled = photonView.IsMine;
        //SteamVRRight.transform.Find("Model").gameObject.SetActive(photonView.IsMine);
        //SteamVRRight.GetComponent<Hand>().enabled = photonView.IsMine;
        //SteamVRRight.GetComponent<HandPhysics>().enabled = photonView.IsMine;

        // Camera activation if UserMe, deactivation if UserOther
        SteamVRCamera.GetComponent<Camera>().enabled = photonView.IsMine;

        //if (!photonView.IsMine)
        //{
            // ONLY for player OTHER

            // Create the model of the LEFT Hand for the UserOther, use a SteamVR model  Assets/SteamVR/Models/vr_glove_left_model_slim.fbx
            //var modelLeft = Instantiate(UserOtherLeftHandModel);
            // Put it as a child of the SteamVRLeft Game Object
            //modelLeft.transform.parent = SteamVRLeft.transform;

            // Create the model of the RIGHT Hand for the UserOther Assets/SteamVR/Models/vr_glove_right_model_slim.fbx
            //var modelRight = Instantiate(UserOtherRightHandModel);
            // Put it as a child of the SteamVRRight Game Object
            //modelRight.transform.parent = SteamVRRight.transform;
        //}
    }
}
