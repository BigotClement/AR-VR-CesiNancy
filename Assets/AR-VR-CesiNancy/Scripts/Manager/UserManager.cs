using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class UserManager : MonoBehaviourPunCallbacks
{
    public static GameObject UserMeInstance;

    private void Awake()
    {
        if (photonView.IsMine)
        {
            UserMeInstance = gameObject;
        }
    }
}
