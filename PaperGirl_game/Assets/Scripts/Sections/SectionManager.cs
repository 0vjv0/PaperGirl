/* Procedurally rearrenges the position
of the different sections of the game scenario
to create a continuous path */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralRegeneration
{
    public class SectionManager : MonoBehaviour
    {
        [SerializeField] List<GameObject> Sections;
        GameObject Crossing; 
        GameObject LevelEnd; 

        // Según la dificultad #TODO
        public int preCrossing = 10;
        public int RearrengedSections = 0;
        int maxSections = 15;
        // Según la dificultad

        // Según el barrio #TODO
        float tileWidth = 28f;
        float endTileWidth = 45f;
        // Según el barrio

        void Start()
        {
            Sections = new List<GameObject>();

            Crossing = GameObject.Find("Crossing");
            LevelEnd = GameObject.Find("LevelEnd");

            Sections.Add(GameObject.Find("Section1"));
            Sections.Add(GameObject.Find("Section2"));
            Sections.Add(GameObject.Find("Section3"));
            Sections.Add(GameObject.Find("Section4"));
            Sections.Add(GameObject.Find("Section5"));
        }

        public void Rearrange(float Zposition)
        {   
            RearrengedSections += 1;

            // Inserte the End of level
            if(RearrengedSections == maxSections)
            {
                Vector3 newPosition = new Vector3(0f, 0f, Zposition + endTileWidth);
                LevelEnd.transform.position = newPosition;
            }
            // Insert crossing
            else if (RearrengedSections !=0 && RearrengedSections % preCrossing == 0)
            {
                Vector3 newPosition = new Vector3(0f, 0f, Zposition + tileWidth);
                Crossing.transform.position = newPosition;
            }
            // Move first section to last position in scene and list
            else
            {
                GameObject SectiontoMove = Sections[0];

                Sections.RemoveAt(0);
                SectiontoMove.GetComponent<Section>().CreateNewTile();

                Vector3 newPosition = new Vector3(0f, 0f, Zposition + tileWidth);
                SectiontoMove.transform.position = newPosition;

                Sections.Add(SectiontoMove);
            }
        }
    }
}
