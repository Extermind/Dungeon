using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyStates enemyState;
    public enum EnemyStates
    {
        TURN,
        END_TURN
    }

    public void setEndTurnEnemy()
    {
        enemyState = EnemyStates.END_TURN;
    }


    //Z listy Enemy zostaje wybrany przciwnik losowy który jest w tym pokoju (numer pokoju ID)
    
    Enemy chooseEnemy()
    {
        //temporary
        return new Enemy();
    }

    void enemyTurn(Enemy e)
    {
        
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
