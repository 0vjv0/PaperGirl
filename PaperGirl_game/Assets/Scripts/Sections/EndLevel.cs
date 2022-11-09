/*
Special section that
starts the end of the game level
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    static LevelManager levelManager;

    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Movement>().IsFinished = true;

            Invoke ("NextLevel", 2);
        }
    }

    void NextLevel()
    {
        levelManager.EndOfLevel();
    }
}
