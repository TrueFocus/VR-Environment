using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.XR.CoreUtils;

public class RecenterOrigin : MonoBehaviour
{
    public InputActionProperty recenterButton;
    public GameObject WorldSpawn;
    private Transform WorldSpawnTransform;
    public GameObject Camera;
    private float VerticalOffset;
    private float platformHeight = 0f;

    // Start is called before the first frame update
    void Start()
    {
        WorldSpawnTransform = WorldSpawn.GetComponent<Transform>();
        //initialVerticalOffset = Camera.GetComponent<Transform>().position.y;

        //Debug.Log(VEOriginTransform);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(recenterButton.action.WasPressedThisFrame()){
            VerticalOffset = Camera.GetComponent<Transform>().position.y;
            Recenter();
        }
    }

    public void Recenter(){
        XROrigin xrOrigin = GetComponent<XROrigin>();
        xrOrigin.MoveCameraToWorldLocation(WorldSpawnTransform.position + Vector3.up*(VerticalOffset-platformHeight));
        xrOrigin.MatchOriginUpCameraForward(WorldSpawnTransform.up, WorldSpawnTransform.forward);
    }
}
