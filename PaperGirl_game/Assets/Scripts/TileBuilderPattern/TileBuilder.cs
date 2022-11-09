/* 
Abstract builder
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileBuilderPattern
{
    public abstract class TileBuilder
    {
        protected Tile tileObject;
        public List<GameObject> HousePool = new List<GameObject>();
        public int TreeDensity;
        public void SetSpawns(Transform houseSpawn, List<Transform> forestSpawns)
        {
            tileObject.SetSpawnPoints(houseSpawn, forestSpawns);
        }
        public abstract void SetPool(PoolManager pool);
        public void SetHouse()
        {
            int rand = Random.Range(0, tileObject.HousePool.Count);
            tileObject.House = tileObject.HousePool[rand];
        }
        public void SetTreeList()
        {
            tileObject.treeList = GameObject.Find("Pool").GetComponent<PoolManager>().GetTrees();
        }
        public abstract void SetTreeDensity();




        public void SetVehicleList()
        {
           /*  Transform pool = tileObject.Pool.transform.Find("Vehicles");
            foreach(Transform vehicle in pool)
            {
                tileObject.TreeList.Add(vehicle.gameObject);
            } */
        }

        //Npc
            //Vehicle
            //Obstacles
            //PowerUp

       public void CreateNewTile()
        {
            tileObject = new Tile();
        }
        public Tile GetTile()
        {
            return tileObject;
        }
    }
}