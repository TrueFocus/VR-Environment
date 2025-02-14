//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;

namespace RosMessageTypes.Wham
{
    [Serializable]
    public class LedlistMsg : Message
    {
        public const string k_RosMessageName = "wham/ledlist";
        public override string RosMessageName => k_RosMessageName;

        public HeaderMsg header;
        public int[] leds;

        public LedlistMsg()
        {
            this.header = new HeaderMsg();
            this.leds = new int[16];
        }

        public LedlistMsg(HeaderMsg header, int[] leds)
        {
            this.header = header;
            this.leds = leds;
        }

        public static LedlistMsg Deserialize(MessageDeserializer deserializer) => new LedlistMsg(deserializer);

        private LedlistMsg(MessageDeserializer deserializer)
        {
            this.header = HeaderMsg.Deserialize(deserializer);
            deserializer.Read(out this.leds, sizeof(int), 16);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.header);
            serializer.Write(this.leds);
        }

        public override string ToString()
        {
            return "LedlistMsg: " +
            "\nheader: " + header.ToString() +
            "\nleds: " + System.String.Join(", ", leds.ToList());
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }
}
