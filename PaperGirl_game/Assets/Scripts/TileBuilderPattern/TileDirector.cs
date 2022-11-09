/* Director of the builder pattern
Called by each section when it is repositioned
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileBuilderPattern
{
    public class TileDirector
    {
        public Tile MakeTile(TileBuilder tileBuilder, PoolManager pool, Transform houseSpawn, List<Transform> forestSpawns)
        {
            tileBuilder.CreateNewTile();
            tileBuilder.SetSpawns(houseSpawn, forestSpawns);
            tileBuilder.SetPool(pool);         
            tileBuilder.SetHouse();
            tileBuilder.SetTreeList();
            tileBuilder.SetTreeDensity();
            //tileBuilder.SetTreeLimit(); 
            //tileBuilder.SetTreeList();
            //tileBuilder.SetVehicleList();

            //Npc
            //Obstacles
            //PowerUp

            return tileBuilder.GetTile();
        }
    }
}