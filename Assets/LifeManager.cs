using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
  
    private string carried_tag;
    private int health;
    public string ennemy_tag;
    // Start is called before the first frame update
    void Start()
    {

        tag = gameObject.tag;
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ennemy_tag + "_bullet")
        {
            Destroy(other.gameObject);
            health = health - 1;
            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
