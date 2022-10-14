using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody m_Rigidbody;
    public float m_Speed;


    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Speed = 10.0f;
        Destroy(gameObject, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        m_Rigidbody.velocity = transform.forward * m_Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Gun")
        {
            Destroy(gameObject);
        }
    }
}
