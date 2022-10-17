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
    [SerializeField] 
    private string m_BulletTag;

    private TextMeshProUGUI m_textHealth;

    

    private void Start()
    {
        Physics.IgnoreCollision(m_collider, m_charController);
        m_textHealth = GameObject.FindGameObjectWithTag("Health").GetComponent<TextMeshProUGUI>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == m_BulletTag)
        {

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
