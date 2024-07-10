using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Sensor;
using UnityEngine;

public class ArmSubscriber : MonoBehaviour
{
    public GameObject[] joints;
    private Transform[] jointTransforms; 
    private float[] jointStateFixed = new float[7];

    void Start()
    {
        // Obtains the transforms of each joint.
        jointTransforms = new Transform[joints.Length];
        for (int i = 0; i < joints.Length; i++)
        {
            jointTransforms[i] = joints[i].GetComponent<Transform>();
        }

        // Initializes the ROSConnection with the joint_states topic.
        ROSConnection.GetOrCreateInstance().Subscribe<JointStateMsg>("franka_state_controller/joint_states", UpdateJoints);
    }

    // Updates the local rotation of the joints based on what is received through ROS.
    void UpdateJoints(JointStateMsg jointStateMessage)
    {
        for(int i=0; i<joints.Length; i++){
            jointStateFixed[i] = (float)jointStateMessage.position[i]*180/Mathf.PI;
        }

        jointTransforms[0].localRotation = Quaternion.Euler(0, -jointStateFixed[0], 0);
        jointTransforms[1].localRotation = Quaternion.Euler(jointStateFixed[1],0, 90);
        jointTransforms[2].localRotation = Quaternion.Euler(-jointStateFixed[2],0, -90);
        jointTransforms[3].localRotation = Quaternion.Euler(-jointStateFixed[3],0, -90);
        jointTransforms[4].localRotation = Quaternion.Euler(jointStateFixed[4],0, 90);
        jointTransforms[5].localRotation = Quaternion.Euler(-jointStateFixed[5],0, -90);
        jointTransforms[6].localRotation = Quaternion.Euler(-jointStateFixed[6],0, -90);

    }
}
