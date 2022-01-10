using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Pozwala to odnosic sie do tego skryptu w innych skryptach bez tworzenia obiektu GameManager - wystarczy GameManager.instance.gold (np.) ;
                                        // Bedzie stad mozna zarzadzac scenami (teleportacja gracza) 

    public int points;

}
