using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //could be:
        //1-awake
        //2-onEnable
        //3-constructor
        Debug.Log("Hello World");
        Debug.LogWarning("Warning");
        Debug.LogError("Error");
        Debug.Log("My name is" + this.gameObject.name);//we can write without this keyword, this used by java programmer
    }

    // Update is called once per frame
    void Update()
    {
        //there is other options
        //lateUpdate
        //fixedUpdate use it when driven by physics
        //e.g.update--> mario moving and lateupdate--> camera moving
        Debug.Log("Update");
       
    }
}
