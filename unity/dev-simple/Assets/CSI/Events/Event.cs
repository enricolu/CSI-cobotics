using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace CSI.Events 
{
    public class Event
    {
        // Internal properties
        private DateTime timeStamp = DateTime.Now;

        // Constructor
        public Event()
        {

        }

        // Get the current time-stamp
        public static String GetDateString(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssfff");
        }
    }
}
