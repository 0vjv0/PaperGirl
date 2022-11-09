/* 
Concrete builder
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileBuilderPattern
{
    class SuburbTile: TileBuilder
    {
        
        public override void SetPool(PoolManager pool)
        {
            tileObject.HousePool = pool.GetSuburbHouses();
        }
        public override void SetTreeDensity()
        {
            tileObject.treeDensity = 1;
        }
    }
}