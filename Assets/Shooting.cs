using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Shooting : MonoBehaviour
{
    public GameObject Bullet_Prefab;
    GameObject new_bullet;
    public string carried_tag;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Actions._default.ShootRight.GetStateDown(SteamVR_Input_Sources.Any))
            {
            
            new_bullet = Instantiate(Bullet_Prefab,gameObject.transform.position,gameObject.transform.rotation);
            new_bullet.tag = (carried_tag + "_bullet").ToString();

            }
    }

    
}
