using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using LedState = RosMessageTypes.Wham.LedlistMsg;
using System.Text;

public class GameSubscriber : MonoBehaviour
{
    private int numberOfButtons = 6;
    public GameObject[] buttons;
    public Material buttonStateOn;
    public Material buttonStateOff;

    void Start()
    {
        // Initializes the ROSConnection with the ledstate topic.
        ROSConnection.GetOrCreateInstance().Subscribe<LedState>("ledstate", UpdateButtonColor);
    }

    void UpdateButtonColor(LedState ledStateMessage)
    {
        // Provides a debug message displaying the states of the 16-bit ledstate topic.
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < ledStateMessage.leds.Length; i++)
        {
            sb.Append(ledStateMessage.leds[i]);
            sb.Append(" ");
        }
        Debug.Log(sb.ToString());

        // Updates the lighting state of the buttons based on what is received through ROS.
        for(int i = 0; i<numberOfButtons; i++){
            if(ledStateMessage.leds[i] == 1){
                buttons[i].GetComponent<Renderer>().material = buttonStateOn;
            }else if(ledStateMessage.leds[i] == 0){
                buttons[i].GetComponent<Renderer>().material = buttonStateOff;
            }
        }
    }
}