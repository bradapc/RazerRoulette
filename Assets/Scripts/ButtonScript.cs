using UnityEngine;
//push tester
public class ButtonScript : MonoBehaviour
{
    public GameObject rouletteWheel;
    public GameObject logicHandler;
    public HingeJoint2D rouletteWheelRB;

    private TalkingScript talkScript;

    public int wheelValue = 1;
    public string turn = "null";

    //onClick parameters
    public float currentTime = 0;
    public float randomTime = 0;
    public float timeToSpin = 0;
    public int wheelvalue = 0;
    public int generatedRotation = 0;

    public float countdownTime = 3f;
    private float spinRandomTimer = 0f;
    public bool spinnerActivated = false;
    public bool delayFinished = true;
    public bool spunForEnemy = false;
    public bool spunForPlayer = true;

    JointMotor2D motor;

    public int damageValue = 1;
    public bool doubleSpin = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rouletteWheelRB = rouletteWheel.GetComponent<HingeJoint2D>();
        motor = rouletteWheelRB.motor;
        turn = "null";
        
        talkScript = logicHandler.GetComponent<TalkingScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!delayFinished) {
            spinRandomTimer -= Time.deltaTime;
            spinRandomTimer = Mathf.Clamp(spinRandomTimer, 0, 3);
            if (spinRandomTimer <= 0) {
                delayFinished = true;
                doEnemyTurn();
            }
        }
        if(spinnerActivated){
            motor.motorSpeed = 400;
            rouletteWheelRB.motor = motor;
            if(spinRandomTimer > 0){
                spinRandomTimer -= Time.deltaTime;
                spinRandomTimer = Mathf.Clamp(spinRandomTimer, 0, countdownTime);
            }
            else{
                int currentRotation = (int)rouletteWheel.transform.rotation.eulerAngles.z;
                if (currentRotation > generatedRotation - 15 && currentRotation < generatedRotation + 15) {
                    motor.motorSpeed = 0;
                    rouletteWheelRB.motor = motor;
                    spinnerActivated = false;
                    logicHandler.GetComponent<WheelScript>().handleTurnEnd(wheelValue, getOutcomeTarget(wheelValue), damageValue);
                    if(!doubleSpin){
                        handleNextTurn(wheelValue);
                    }
                    else{
                        doubleSpin = false;
                    }
                }
            }
        }
    }

    public bool getWheelValueOutcome(int wheelValue) {
        return !(logicHandler.GetComponent<WheelScript>().appleMap[wheelValue - 1]);
    }

    public void handleNextTurn(int wheelValue) {
        if (turn == "player" && spunForEnemy && getWheelValueOutcome(wheelValue)) {
            turn = "enemy";
            
        } else if (turn == "player" && spunForEnemy && !getWheelValueOutcome(wheelValue)) {
            turn = "player";
        } else if (turn == "player" && getWheelValueOutcome(wheelValue)) {
            turn = "player";
        } else if (turn == "player" && !getWheelValueOutcome(wheelValue)) {
            turn = "enemy";

        } else if (turn == "enemy" && spunForPlayer && getWheelValueOutcome(wheelValue)) {
            turn = "null";
            logicHandler.GetComponent<ItemScript>().selectItem("player");
        } else if (turn == "enemy" && spunForPlayer && !getWheelValueOutcome(wheelValue)) {
            turn = "enemy";
            
        } else if (turn == "enemy" && getWheelValueOutcome(wheelValue)) {
            turn = "enemy";
        
        } else if (turn == "enemy" && !getWheelValueOutcome(wheelValue)) {
            turn = "null";
            logicHandler.GetComponent<ItemScript>().selectItem("player");
        }
        spunForEnemy = false;
        spunForPlayer = false;
        Debug.Log(" before turn swap");
        Debug.Log(turn);
        if (turn == "enemy") {
            Debug.Log("turn swap");
            delayFinished = false;
            spinRandomTimer = 3;
        }
    }

    public string getOutcomeTarget(int wheelValue) {
        if (turn == "player" && spunForEnemy) {
            
            return "enemy";
        } else if (turn == "player") {
            
            return "player";
        } else if (turn == "enemy" && spunForPlayer) {
            
            return "player";
        } else {
            
            return "enemy";
        }
    }

    public void doPlayerTurn() {
        if (turn == "player") {
            wheelValue = Random.Range(1, 13);
            generatedRotation = wheelValue* (360 / 12);
            countdownTime = Random.Range(1, 3);
            spinRandomTimer = countdownTime;
            spinnerActivated = true;
        }
    }

    public void doEnemyTurn() {
        if (turn == "enemy") {
            if (delayFinished) {
                int enemyChoice = Random.Range(1, 4);
                Debug.Log(enemyChoice);
                if (enemyChoice == 1) {
                    //Do turn for himself
                    talkScript.changeText("I shall worsen the odds!");
                    spunForPlayer = false;
                } else if (enemyChoice == 2 || enemyChoice == 3 ) {
                    //Do turn for player
                    talkScript.changeText("This is for you!");
                    spunForPlayer = true;
                }
                wheelValue = Random.Range(1, 13);
                generatedRotation = wheelValue* (360 / 12);
                countdownTime = Random.Range(1, 3);
                spinRandomTimer = countdownTime;
                spinnerActivated = true;
            }
        }
    }

    public void doEnemyTurnFromPlayer() {
        if (turn == "player") {
            wheelValue = Random.Range(1, 13);
            generatedRotation = wheelValue* (360 / 12);
            countdownTime = Random.Range(1, 3);
            spinRandomTimer = countdownTime;
            spinnerActivated = true;
            spunForEnemy = true;
        }
    }
    

    public void onClick() {
        Debug.Log(turn);
        if (turn == "player") {
            doPlayerTurn();
            talkScript.changeText("You think luck will be on your side?");
        }

    }

    public void onClickEnemyHit() {
        if (turn == "player") {
            talkScript.changeText("For me... You shouldn't have!");
            
            doEnemyTurnFromPlayer();
        }

    }
}