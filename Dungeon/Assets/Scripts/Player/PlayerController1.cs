using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{

    [SerializeField]
    private int actionsPointsAmount = 30;
    [SerializeField]
    private int actionsPoints = 0;
    

    [SerializeField]
    private int movementCostPoints = 5;



    private PlayerActionsScript pa;
    
    private Vector2 input;
    public Vector3 direction;

    private float moveSpeed = 5f;
    [SerializeField]
    private Transform movePoint;


    public PlayerStates PlayerState;
    public enum PlayerStates
    {
        IDLE,
        MOVING,
        ATTACK,
        END_TURN
    }



    private void Awake()
    {
        pa = new PlayerActionsScript();

        //read input value
        pa.player.movement.performed += x =>
        {
            input = x.ReadValue<Vector2>();
        };
        //nie trzeba nasłuchiwać kiedy klawisz został psuzczony bo kierunek ma sie zmieniać tylko wtedy kiedy gracz kliknie przycisk
        //pa.player.movement.canceled += x => direction = x.ReadValue<Vector2>();
        pa.player.move.performed += x => PlayerState = PlayerStates.MOVING;
        //pa.player.move.canceled += x => PlayerState = PlayerStates.IDLE;

        //to wyżej mogę przerobić na podwójne kliknięcie danego klawisza kierunku ruchu
        //1 to wybór strony w którym sie idzie
        //2 to iście w danym kierunku


    }
    private void OnEnable()
    {
        pa.Enable();
    }
    private void OnDisable()
    {
        pa.Disable();
    }


    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;

        //actionsPoints = actionsPointsAmount;
    }

    // Update is called once per frame
    void Update()
    {

        

        switch (PlayerState)
        {
            case PlayerStates.IDLE:
                if(actionsPoints < 4)
                {
                    PlayerState = PlayerStates.END_TURN;
                    break;
                }
               
                if (Mathf.Abs(input.x) == 1f)
                {
                    direction = new Vector3((float)input.x, 0, 0);
                }
                if (Mathf.Abs(input.y) == 1f)
                {
                    direction = new Vector3(0, (float)input.y, 0);
                }

                break;
            case PlayerStates.MOVING:
                movePoint.position += direction;
                transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);// tutaj jest problem z tą funckją
                
                StartCoroutine(wait());
               
                actionsPoints -= movementCostPoints;
                PlayerState = PlayerStates.IDLE;
                break;

            case PlayerStates.ATTACK:



                break;
            case PlayerStates.END_TURN:
                //wait for game menager
                break;
        }

        IEnumerator wait()
        {
            yield return new WaitForSeconds(2);
            Debug.Log("end of waiting");
        }

        



        ////move player
        //transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);


        //if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f && actionsPoints >= movementCostPoints)  
        //{ 
        //    if (Mathf.Abs(movement.x) == 1f)
        //    {
        //        movePoint.position += new Vector3((float)movement.x, 0, 0);
        //        //_actionsPoints -= movementCostPoints;
        //    }
        //    if (Mathf.Abs(movement.y) == 1f)
        //    {
        //        movePoint.position += new Vector3(0, (float)movement.y, 0);
        //        //_actionsPoints -= movementCostPoints;
        //    }
        //}

        //if(Vector3.Distance(transform.position, movePoint.position) == 1f)
        //{
        //    actionsPoints -= movementCostPoints;
        //}

    }



    public void resetActionPoints()
    {
        actionsPoints = actionsPointsAmount;
        PlayerState = PlayerStates.IDLE;
    }
    public int getActionPoints()
    {
        return actionsPoints; 
    }
    
    public bool canMakeAction()
    {
        if(actionsPoints >= 5) 
        { return true; }
        else
        {
            return false;
        }
    }
}
