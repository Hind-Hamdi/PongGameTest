using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleMoves : MonoBehaviour
{

   
    // Start is called before the first frame update
    public float m_moveSpeed = 1000.0f;//let the designer decied how much fast(i wrote 100)
    //constrain the puddle position (to not to go out of the screen)
    public const float HALF_WIDTH = 75.0f; //for the puddle
    public const float HALF_HIGHT = 10.0f;
    public const float WALL_WIDTH = 20.0f;//for the wall
    private void OnConnectedToServer()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 move = Vector3.zero;// I am only using the x, but I will be adding to vector.....
        if (Input.GetKey(KeyCode.RightArrow))
        {
            move.x += 1.0f;

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move.x -= 1.0f;

        }
        if (Input.GetKey(KeyCode.A))
        {
            move.x += 1.0f;

        }
        if (Input.GetKey(KeyCode.D))
        {
            move.x -= 1.0f;

        }
        //-------------------------------------------------
        // if (Input.GetKey(KeyCode.UpArrow))
        // { 
        //     move.y += 1.0f;

        //  }
        // if (Input.GetKey(KeyCode.DownArrow))
        // {
        //    move.y -= 1.0f;

        //}
        //-------------------------------------------------
        //to make sure no one move by 2 steps for cheating
        move.x=Mathf.Clamp(move.x,-1.0f,1.0f);//just to but it in the same boundery(if the user press left+A we will make sure that the step dosenot move by 2 steps
        move.y = Mathf.Clamp(move.y, -1.0f, 1.0f);
       
        //move the puddle
        pos += m_moveSpeed * move * Time.deltaTime;
       
        //constrain the --(the constrans should be the last)
        pos.x = Mathf.Clamp(pos.x, HALF_WIDTH + WALL_WIDTH, Screen.width - WALL_WIDTH - HALF_WIDTH);
        transform.position = pos;
    }
}
