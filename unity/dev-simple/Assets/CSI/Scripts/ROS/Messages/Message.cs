using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CSI.ROS.Messages
{
    public abstract class Message : RosSharp.RosBridgeClient.Message
    {
        protected Message() { }
    }
}
