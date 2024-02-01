using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton instance;

    /*
    // Variables
    [HideInInspector]
    public int currentScore = 0;
    public int minimumScore, maximumScore;
    [HideInInspector]
    public int finalScore;
    [HideInInspector]
    public int highScore;
    [HideInInspector]
    public bool incrementScore = false;
    [HideInInspector]
    public bool tapEnabled = false;
    [HideInInspector]
    public bool gameOver = false;
    public enum GameState {
        TitleState,
        IdleInState,
        PlayState,
        ScoreState,
        IdleOutState
    }
    [HideInInspector]
    public GameState gameState = GameState.TitleState;
    
    [HideInInspector]
    public string player_rfid_serial_number = "";
    public bool isLoggedIn = false;
    public bool isIdle = false;
     */

    //--
    [HideInInspector]
    public int currentScore = 0;


    // Singleton Instance
    public static Singleton Instance {
        get { return instance; }
    } //-- Singleton Instance


    private void Awake() {
        if(instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    } //-- Awake end

} //-- class end


/*
Project: 
Made by: 
*/

