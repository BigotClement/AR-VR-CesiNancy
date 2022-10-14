using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhotonView))]
public class PhotonTransformChildView : MonoBehaviourPunCallbacks, IPunObservable
{
    public bool SynchronizePosition;
    public bool SynchronizeRotation;
    public bool SynchronizeScale;

    public List<Transform> SynchronizedChildTransform;
    private List<Vector3> localPositionList;
    private List<Quaternion> localRotationList;
    private List<Vector3> localScaleList;

    private void Awake()
    {
        localPositionList = new List<Vector3>(SynchronizedChildTransform.Count);
        localRotationList = new List<Quaternion>(SynchronizedChildTransform.Count);
        localScaleList = new List<Vector3>(SynchronizedChildTransform.Count);
        for (int i = 0; i < SynchronizedChildTransform.Count; i++)
        {
            localPositionList.Add(Vector3.zero);
            localRotationList.Add(Quaternion.identity);
            localScaleList.Add(Vector3.one);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
        {
            for (int i = 0; i < SynchronizedChildTransform.Count; i++)
            {
                if (SynchronizePosition)
                    SynchronizedChildTransform[i].localPosition = localPositionList[i];

                if (SynchronizeRotation)
                    SynchronizedChildTransform[i].localRotation = localRotationList[i];

                if (SynchronizeScale)
                    SynchronizedChildTransform[i].localScale = localScaleList[i];
            }
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Code for sending data to synchronize
            for (int i = 0; i < SynchronizedChildTransform.Count; i++)
            {
                if (SynchronizePosition)
                    stream.SendNext(SynchronizedChildTransform[i].localPosition);

                if (SynchronizeRotation)
                    stream.SendNext(SynchronizedChildTransform[i].localRotation);

                if (SynchronizeScale)
                    stream.SendNext(SynchronizedChildTransform[i].localScale);
            }
        }
        else
        {
            // Code for reading data to synchronize
            for (int i = 0; i < SynchronizedChildTransform.Count; i++)
            {
                if (SynchronizePosition)
                    localPositionList[i] = (Vector3)stream.ReceiveNext();

                if (SynchronizeRotation)
                    localRotationList[i] = (Quaternion)stream.ReceiveNext();

                if (SynchronizeScale)
                    localScaleList[i] = (Vector3)stream.ReceiveNext();
            }
        }

    }
}
