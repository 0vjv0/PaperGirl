/* Builder's product
Set of objects that forms every section
(House, 
forest (behind the house and across the road,...)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileBuilderPattern
{
    public class Tile
    {
        public List<GameObject> HousePool;
        public GameObject House { get; set; }
        public Transform houseSpawn { get; set; }
        public List<Transform> treesSpawns { get; set; }
        public List<GameObject> treeList = new List<GameObject>();
        public int treeDensity { get; set; }
      
        //Npc
        //Vehicle
        //Obstacles

        public void SetSpawnPoints(Transform houseSpawn, List<Transform> treesSpawns)
        {
            this.houseSpawn = houseSpawn;
            this.treesSpawns = treesSpawns;
        }

        public void DisplayTile()
        {
            NewHouse();
            NewForest();
            //NewVehicle();
            //Npc
            //Obstacles
            //PowerUp
        }
        void NewHouse()
        {
            GameObject house = GameObject.Instantiate(House, houseSpawn.position, houseSpawn.rotation, houseSpawn);
        }
        
        void NewForest()
        {
            int randA = Random.Range(0, treeList.Count);
            GameObject TreeGroup = treeList[randA];

            List<GameObject> specificTrees = new List<GameObject>();
            foreach(Transform t in TreeGroup.transform)
            {
                specificTrees.Add(t.gameObject);
            }

            foreach(Transform SpawnPoint in treesSpawns)
            {
                for(int i = 0; i <= treeDensity; i++)
                {
                    int randB = Random.Range(0, specificTrees.Count);
                    GameObject aTree = GameObject.Instantiate(specificTrees[randB], SpawnPoint);
                    
                    Vector2 point = Random.insideUnitCircle * 2; // HARDCODED
                    aTree.transform.position = SpawnPoint.position + new Vector3(point.x, 0f, point.y);
                }
            }
            
        }
    }
}