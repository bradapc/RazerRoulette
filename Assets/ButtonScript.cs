using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject rouletteWheel;
    public GameObject logicHandler;
    public HingeJoint2D rouletteWheelRB;
    private float timer = 0.0f;
    public int wheelValue = 1;
    public string turn = "player";

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

    JointMotor2D motor;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rouletteWheelRB = rouletteWheel.GetComponent<HingeJoint2D>();
        motor = rouletteWheelRB.motor;
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
                    logicHandler.GetComponent<WheelScript>().handleTurnEnd(wheelValue, getOutcomeTarget(wheelValue));
                    handleNextTurn(wheelValue);
                }
            }
        }
    }

    public bool getWheelValueOutcome(int wheelValue) {
        return logicHandler.GetComponent<WheelScript>().appleMap[wheelValue - 1];
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
        } else if (turn == "enemy" && getWheelValueOutcome(wheelValue)) {
            turn = "enemy";
        } else if (turn == "enemy" && !getWheelValueOutcome(wheelValue)) {
            turn = "player";
        }
        spunForEnemy = false;
        if (turn == "enemy") {
            delayFinished = false;
            spinRandomTimer = 3;
        }
    }

    public string getOutcomeTarget(int wheelValue) {
        if (turn == "player" && spunForEnemy && getWheelValueOutcome(wheelValue)) {
            return "enemy";
        } else if (turn == "player" && spunForEnemy && !getWheelValueOutcome(wheelValue)) {
            return "enemy";
        } else if (turn == "player" && getWheelValueOutcome(wheelValue)) {
            return "player";
        } else if (turn == "player" && !getWheelValueOutcome(wheelValue)) {
            return "player";
        }
        //add enemy
        return "enemy";
    }

    public void doPlayerTurn() {
        if (turn == "player") {
            wheelValue = Random.Range(1, 12);
            generatedRotation = wheelValue* (360 / 12);
            countdownTime = Random.Range(1, 3);
            spinRandomTimer = countdownTime;
            spinnerActivated = true;
        }
    }

    public void doEnemyTurn() {
        if (turn == "enemy") {
            if (delayFinished) {
                wheelValue = Random.Range(1, 12);
                generatedRotation = wheelValue* (360 / 12);
                countdownTime = Random.Range(1, 3);
                spinRandomTimer = countdownTime;
                spinnerActivated = true;
            }
        }
    }

    public void doEnemyTurnFromPlayer() {
        if (turn == "player") {
            wheelValue = Random.Range(1, 12);
            generatedRotation = wheelValue* (360 / 12);
            countdownTime = Random.Range(1, 3);
            spinRandomTimer = countdownTime;
            spinnerActivated = true;
            spunForEnemy = true;
        }
    }
    

    public void onClick() {
        if (turn == "player") {
            doPlayerTurn();
        }
    }

    public void onClickEnemyHit() {
        if (turn == "player") {
            doEnemyTurnFromPlayer();
        }
    }
}