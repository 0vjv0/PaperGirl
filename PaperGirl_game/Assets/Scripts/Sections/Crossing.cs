/*
Special section that
does not create a new tile but
does call the function of rearranging sections
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ProceduralRegeneration
{

    public class Crossing : MonoBehaviour
    {
        static SectionManager sectionManager;

        void Awake()
        {
            sectionManager = GameObject.Find("Home").GetComponent<SectionManager>();         
        }

        void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                sectionManager.Rearrange(transform.position.z);
            }
        }
    }
}
