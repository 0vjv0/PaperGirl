/*
It manages the gameobjects pool. 
Returns object lists based on neighborhood and difficulty level.
Unfinished
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileBuilderPattern
{
    public class PoolManager : MonoBehaviour
    {
        static LevelManager levelManager;

        int Difficulty;
        [SerializeField] List<GameObject> SuburbHouses = new List<GameObject>();
        [SerializeField] List<GameObject> HighHouses = new List<GameObject>();
        [SerializeField] List<GameObject> FactoryBuildings = new List<GameObject>();
        [SerializeField] List<GameObject> SmallTrees = new List<GameObject>();
        [SerializeField] List<GameObject> MediumTress = new List<GameObject>();
        [SerializeField] List<GameObject> LargeTrees = new List<GameObject>();
        [SerializeField] List<GameObject> ExtraLargeTress = new List<GameObject>();
        /* [SerializeField] List<GameObject> Cars = new List<GameObject>();
        [SerializeField] List<GameObject> Trucks = new List<GameObject>();
        [SerializeField] List<GameObject> People = new List<GameObject>();
        [SerializeField] List<GameObject> Pets = new List<GameObject>();
        [SerializeField] List<GameObject> Obstacles = new List<GameObject>();
 */

        void Awake()
        { 
            levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
            Difficulty = levelManager.GetDate();//
        }

        public List<GameObject> GetSuburbHouses()
        {
            return SuburbHouses;
        }

        public List<GameObject> GetHighHouses()
        {
            return HighHouses;
        }

        public List<GameObject> GetFactoryBuildings()
        {
            return FactoryBuildings;
        }
        public List<GameObject> GetTrees()
        {

            if(Difficulty < 26)
                return SmallTrees;
            else if(Difficulty < 51)
                return MediumTress;
            else if(Difficulty < 76)
                return LargeTrees;
            else
                return ExtraLargeTress;
            
        }
    }
}
