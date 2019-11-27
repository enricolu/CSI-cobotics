using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CSI;

namespace CSI.User 
{
    [Serializable]
    public class User : Entity
    {

        // Before timeseries
        void Awake()
        {
            AssignEntityType(EntityType.user);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
