﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstanceIdTest : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.name + " ID: " + GetComponent<Slider>().GetInstanceID());
    }
}
