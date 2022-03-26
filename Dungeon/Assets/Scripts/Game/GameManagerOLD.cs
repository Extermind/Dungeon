using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerOLD : MonoBehaviour
{
    public GameObject p;   // gameobject of player
    private PlayerControllerOLD player;
    private EnemyManager enemyManager;

    private Enemy enemy;
    public GameState gs;

    public enum GameState
    {
        DEFAULT, //should never happen
        PLAYER_RESET,
        PLAYER_TURN,
        ENEMY_TURN,
        ENEMY_RESET,
        PLAYERS_DEATH,  //END OF GAME   
        WIN             //win
    }


    private void Awake()
    {
        //p = GameObject.FindGameObjectWithTag("Player");
        player = p.GetComponent<PlayerControllerOLD>();
        gs = GameState.PLAYER_RESET;
        

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (gs)
        {
            case GameState.PLAYER_RESET:
                player.resetActionPoints();
                gs = GameState.PLAYER_TURN;
                break;
            case GameState.PLAYER_TURN:
                player.turn();
                if (player.PlayerState == PlayerControllerOLD.PlayerStates.END_TURN)
                {
                    gs = GameState.ENEMY_RESET;
                }
                break;
            case GameState.ENEMY_RESET:
                gs = GameState.ENEMY_TURN;
                break ;
            case GameState.ENEMY_TURN:
                //wait here 2 sec
                Debug.Log("ENEMY TURN");
                gs = GameState.PLAYER_RESET;
                break;




        }
    }

    void DoDelayAction(float delayTime)
    {
        StartCoroutine(DelayAction(delayTime));
    }

    IEnumerator DelayAction(float delayTime)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);

        //Do the action after the delay time has finished.
    }


}
