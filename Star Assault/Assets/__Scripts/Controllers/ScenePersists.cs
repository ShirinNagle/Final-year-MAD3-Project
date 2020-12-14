using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//delete if not required/doing anything
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
