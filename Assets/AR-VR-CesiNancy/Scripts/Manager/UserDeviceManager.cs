using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UserDeviceType
{
    HTC,
    PC
}

public class UserDeviceManager : MonoBehaviour
{
    public static UserDeviceType GetDeviceUsed()
    {
        string deviceUsed = AppConfig.Inst.DeviceUsed.ToLower();

        switch (deviceUsed)
        {
            case "htc":
                return UnityEngine.XR.XRSettings.isDeviceActive ? UserDeviceType.HTC : UserDeviceType.PC;

            case "pc":
                return UserDeviceType.PC;

            default:
                return UnityEngine.XR.XRSettings.isDeviceActive ? UserDeviceType.HTC : UserDeviceType.PC;
        }
    }

    public static GameObject GetPrefabToSpawnWithDeviceUsed(GameObject pcPrefab, GameObject HTCPrefab)
    {
        UserDeviceType userDeviceType = GetDeviceUsed();
        switch (userDeviceType)
        {
            case UserDeviceType.HTC:
                return HTCPrefab;
            case UserDeviceType.PC:
            default:
                return pcPrefab;
        }
    }
}
