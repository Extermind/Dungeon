using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private int actionsPointsAmount = 30;
    [SerializeField]
    private int actionsPoints = 0;


    [SerializeField]
    private int movementCostPoints = 5;

    private Vector2 input;
    [SerializeField]
    private Vector3 direction;
    
    private float moveSpeed = 5f;
    [SerializeField]
    private Transform movePoint;

    public int pressindex = 0;


    public PlayerStates PlayerState;
    public enum PlayerStates
    {
        IDLE,
        MOVING,
        ATTACKING,
        END_TURN
    }

    //Input Actions via Code
    //"perfoming"
    private InputAction chooseDirection;
    //triggers
    private InputAction movebtnAction;

    void playerActions()
    {
        //setting up input

        //choosing directions
        chooseDirection = new InputAction("choseDirection");
        //keyboard - WSAD
        chooseDirection.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");
        //Left Stick
        chooseDirection.AddBinding("<Gamepad>/leftStick");


        //Interactions with objects

        //move toward preferd direction
        movebtnAction = new InputAction("movebtnAction",
           type: InputActionType.Button,
           binding: "<Keyboard>/space",
           interactions: "press(behavior=1)");


        //Enable all Actions in OnEnable() func      !!! also remenber to disable them in OnDisable() func
        //chooseDirection.Enable();
        //movebtnAction.Enable();


        //get input only those that are preformed, for buttons we need to check in turn() func [triggers]
        chooseDirection.performed += _ => input = _.ReadValue<Vector2>();
       


    }

    void checkTriggers()
    {
        if (movebtnAction.triggered)
        {
            PlayerState = PlayerStates.MOVING;
        }
    }

    private void Awake()
    {

        playerActions();
        
    }
    private void OnEnable()
    {
        chooseDirection.Enable();
        movebtnAction.Enable();
    }
    private void OnDisable()
    {
        chooseDirection.Disable();
        movebtnAction.Disable();
    }


    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    public void turn()
    {
        checkTriggers();

        //move player
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (Mathf.Abs(input.x) == 1f)
            {
                direction = new Vector3((float)input.x, 0, 0);
                //movePoint.position += new Vector3((float)movement.x, 0, 0);
                //_actionsPoints -= movementCostPoints;
            }
            if (Mathf.Abs(input.y) == 1f)
            {
                direction = new Vector3(0,(float)input.y, 0);
                //movePoint.position += new Vector3(0, (float)movement.y, 0);
                //_actionsPoints -= movementCostPoints;
            }

            //choose new direction point and set it acordlingly xD?
            if (actionsPoints >= movementCostPoints && PlayerState == PlayerStates.MOVING)
            {
                movePoint.position += direction;
                PlayerState = PlayerStates.IDLE;
            }

            //check for "move points" if there are not enough change player state
            if(actionsPoints < movementCostPoints && PlayerState == PlayerStates.IDLE)
            {
                PlayerState = PlayerStates.END_TURN;
            }


        }

        if (Vector3.Distance(transform.position, movePoint.position) == 1f)
        {
            actionsPoints -= movementCostPoints;
        }
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
