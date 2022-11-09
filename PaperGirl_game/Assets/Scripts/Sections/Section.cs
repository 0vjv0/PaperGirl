/*
Scenic piece, which triggers the process of
relocating all pieces when it contacts the player
and calls the constructor pattern to create a
new tile (set of child objects) when it is rearranged
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TileBuilderPattern;

namespace ProceduralRegeneration
{    
    public class Section : MonoBehaviour
    {
        static LevelManager levelManager;
        static SectionManager sectionManager;
        static PoolManager poolManager;
        
        Tile tile;
        TileDirector tileDirector;
        SuburbTile suburbTile;
        HighTile highTile;

        [SerializeField] Transform HouseSpawn;
        [SerializeField] List<Transform> ForestSpawns = new List<Transform>();
        
        void Awake()
        {
            levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
            sectionManager = GameObject.Find("Home").GetComponent<SectionManager>();
            poolManager = GameObject.Find("Pool").GetComponent<PoolManager>();

            tileDirector = new TileDirector();
            
            foreach(Transform child in transform)
            {
                if(child.name == "HouseSpawn")
                {
                    HouseSpawn = child;
                }
                else if(child.name == "Forest")
                {
                    foreach(Transform point in child)
                    {
                        if(point.name == "Spawn")
                            ForestSpawns.Add(point);
                    }
                }
            }
        }

        void Start()
        {
            CreateNewTile();
        }

        void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                sectionManager.Rearrange(transform.position.z);
            }
        }

        public void CreateNewTile()
        {
            CleanAndRotateHouse();
            CleanForest();

            string hood = levelManager.GetHood();

            switch (hood) // Other builders
            {
            case "Suburb":
                suburbTile = new SuburbTile();
                tile = tileDirector.MakeTile(suburbTile, poolManager, HouseSpawn, ForestSpawns); // Forest...
                break;
            case "High":
                highTile = new HighTile();
                tile = tileDirector.MakeTile(highTile, poolManager, HouseSpawn, ForestSpawns);
                break;
           /*  case "Factory":
                westTile = new WestTile();
                tile = tileDirector.MakeTile(westTile, transform);
                break; */
            default:
                break;
            }          
            
            tile.DisplayTile();
        }
        void CleanAndRotateHouse()
        {
            foreach(Transform obj in HouseSpawn)
            {
                if(obj.name != "Ground")
                    Destroy(obj.gameObject);
            }
            
            int rand = Random.Range(0,2);
            if(rand == 0)
                HouseSpawn.eulerAngles = new Vector3(0,90,0);
            else if(rand == 1)
                HouseSpawn.eulerAngles = new Vector3(0,270,0);
        }

        void CleanForest()
        {
            foreach(Transform point in ForestSpawns)
            {
                foreach(Transform tree in point)
                {
                    Destroy(tree.gameObject);
                }
            }
        }
    }
}
