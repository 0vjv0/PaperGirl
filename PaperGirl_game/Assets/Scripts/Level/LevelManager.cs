/* Unfinished 

Controls the flow of the game. It is included in the hierarchy of the first scene,
is responsible for updating the level and its settings
(like day and the date of the game, the neighborhood where the action takes place,
and other features to develop, such as the weather).
Once the settings are defined, additively load scene two, with the game scenario.
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TileBuilderPattern;
class LevelManager: MonoBehaviour
{
    [SerializeField] int currentDate;
    [SerializeField] string Today;
    [SerializeField] string Hood;

   /*  [SerializeField] float rainProb = 0;
    [SerializeField] int temperature = 15;
    [SerializeField] bool ApocalypseMode = false; */

    void Awake()
    {
        //Initial settings
        currentDate = 1;
        Today = "Monday";
        Hood = "Suburb";
        Difficulty = 1f;
        //Write to Sricptable Object

        SceneManager.LoadScene("Neighborhood", LoadSceneMode.Additive);
    }
    public void EndOfLevel()
    {
        SceneManager.UnloadSceneAsync("Neighborhood");
        NextLevelSettings();
        SceneManager.LoadScene("Neighborhood", LoadSceneMode.Additive);
    }

    void NextLevelSettings()
    {
        UpdateCalendar();
        UpdateHood();
        IncreaseDifficulty();
        //UpdateWeather();
        // Writescriptable
    }

    void UpdateCalendar()
    {
        currentDate += 1;

        /* if(currentDate == 22)
        {
            ApocalypseMode = true;
        } */

        switch(Today)
        {
            case "Monday":
                Today = "Tuesday";
                break;
            case "Tuesday":
                Today = "Wednesday";
                break;
            case "Wednesday":
                Today = "Thursday";
                break;
            case "Thursday":
                Today = "Friday";
                break;
            case "Friday":
                Today = "Saturday";
                break;
            case "Saturday":
                Today = "Sunday";
                break;
            case "Sunday":
                Today = "Monday";
                break;
            default:
                break;
        }             
    }

    void UpdateHood()
    {
        switch(Hood)
        {
            case "Suburb":
                Hood = "High";
                break;
            case "High":
                Hood = "Factory";
                break;
            case "Factory":
                Hood = "Race";
                break;
            case "Race":
                Hood = "Suburb";
                break;
            default:
                Hood = "Suburb";
                break;         
        }
    }

    
/*     void UpdateWeather()
    {
        rainProb += Random.Range(1, 10);

        if(currentDate == 7)
        {
                rainProb += 20;
        }
        else if (currentDate == 14)
        {
                rainProb += 20;
        }
        else if (currentDate == 21)
        {
                rainProb += 20;
        }
        temperature += Random.Range(-2, 2);
    }
 */

    public string GetHood()
    {
        return Hood;
    }
    public string GetDay()
    {
        return Today;
    }
    public int GetDate()
    {
        return currentDate;
    }
}

