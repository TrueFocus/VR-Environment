using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamePositionCalibrator : MonoBehaviour
{
    // Input
    public InputActionProperty calibrationButton;
    
    // References to gameobjects relevant to calibration
    public GameObject calibrator;
    private Transform calibratorTransform;
    public GameObject calPosPrimary; // primary calibration position: button 1
    private Transform calPosPrimaryTransform;
    //private Vector3 initialCalPosPrimary;
    public GameObject calPosSecondary; // secondary calibration position: button 6
    private Transform calPosSecondaryTransform;
    //private Vector3 initialCalPosSecondary;
    public GameObject game;
    private Transform gameTransform;
    //private Vector3 initialPosGame;
    private Vector3 calPosPrimaryOffset;
    private Vector3 initialCalibrationVector;
    private float angle;

    // Menu variables
    public bool inPrimaryCalibrationMode;

    void Start()
    {
        inPrimaryCalibrationMode = false;
        calibratorTransform = calibrator.GetComponent<Transform>();
        calPosPrimaryTransform = calPosPrimary.GetComponent<Transform>();
        calPosSecondaryTransform = calPosSecondary.GetComponent<Transform>();
        gameTransform = game.GetComponent<Transform>();

        //calPosPrimaryOffset = calPosPrimaryTransform.position - gameTransform.position;        
        initialCalibrationVector = calPosSecondaryTransform.position - calPosPrimaryTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("In primary calibration mode "+ inPrimaryCalibrationMode);

        if(calibrationButton.action.WasPressedThisFrame() && !inPrimaryCalibrationMode){
            PlacePrimaryCalibrationPosition();
            inPrimaryCalibrationMode = true;
        }else if(calibrationButton.action.WasPressedThisFrame() && inPrimaryCalibrationMode){
            PlaceSecondaryCalibrationPosition();
            inPrimaryCalibrationMode = false;
        }
    }

    public void PlacePrimaryCalibrationPosition(){
        calPosPrimaryOffset = calibratorTransform.position - calPosPrimaryTransform.position;
        gameTransform.position = gameTransform.position + calPosPrimaryOffset;
        Debug.Log("Running first mode, desired position: "+ gameTransform.position);
    }

    public void PlaceSecondaryCalibrationPosition(){
        angle = Vector3.SignedAngle(initialCalibrationVector,  calibratorTransform.position - calPosPrimaryTransform.position, calPosPrimaryTransform.up);
        gameTransform.RotateAround(calPosPrimaryTransform.position, gameTransform.up, angle);
        initialCalibrationVector = calPosSecondaryTransform.position - calPosPrimaryTransform.position;
        Debug.Log("Running second mode, desired angle: "+ angle);        
    }
}
