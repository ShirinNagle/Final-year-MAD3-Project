﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersists : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        int numScenePersists = FindObjectsOfType<ScenePersists>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
