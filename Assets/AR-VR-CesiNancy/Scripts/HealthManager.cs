using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{
    private int m_hp = 10;

    [SerializeField]
    private CapsuleCollider m_collider;
    [SerializeField]
    private CharacterController m_charController;

    private TextMeshProUGUI m_textHealth;

    private void Start()
    {
        //m_collider = transform.parent.GetComponentInChildren<CapsuleCollider>();
        //m_charController = transform.parent.GetComponentInChildren<CharacterController>();
        //m_textHealth = GetComponentInParent GetComponent<CharacterController>();
        Physics.IgnoreCollision(m_collider, m_charController);
        m_textHealth = GameObject.FindGameObjectWithTag("Health").GetComponent<TextMeshProUGUI>();
        Debug.Log(m_textHealth);
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("cul");
        if (other.gameObject.tag == "VRBullet")
        {
            //Debug.Log("touching VR bullet");

            m_hp -= 1;
        
            if (m_hp <= 0)
            {
                //Respawn
                Debug.Log("Dead");
                m_hp = 10;
            }

            m_textHealth.text = m_hp + " / 10";
        }
    }
}
