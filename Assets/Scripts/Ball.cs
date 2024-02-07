using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    //if we didn't write public is private by defualt
    // public 
    //in c# const is a static by default
    public Vector3 m_initVel = new Vector3(100.0f, 200.0f, 0.0f);
    // Vector3 m_velocity = new Vector3(100.0f,200.0f,0.0f);//this is the velocity and direction
    Vector3 m_velocity;
    const float RADIUS = 10.0f;
    public Transform Paddle;
    // public GameObject m_paddle;
    // Start is called before the first frame update
    private void Start()
    {
        m_velocity = m_initVel;
      if (Paddle == null)
        {
             Paddle = FindAnyObjectByType<paddleMoves>().transform;
            //PaddleMove thePaddle = FindAnyObjectByType<PaddleMove>();
            //FirstPaddle= thePaddle.gameObject;  
            //FirstPaddle = FindObjectOfType<FirstPaddle>().transform;
            // GameObject gameObject = new GameObject("paddle");

            // paddleMoves thePaddle = FindAnyObjectByType<paddleMoves>();
          //  m_paddle = thePaddle.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = transform.position;//current position
        pos += m_velocity * Time.deltaTime;//update current position

        //Bounce


        if (m_velocity.y > 0.0f)
        {
            float top = Screen.height - paddleMoves.WALL_WIDTH - RADIUS;
            if (pos.y > top)
            {
                pos.y = top;
                m_velocity.y = -m_velocity.y;
            }
        }
        if (m_velocity.x > 0.0f)
        {
            //check the right wall
            float right = Screen.width - paddleMoves.WALL_WIDTH - RADIUS;
            if (pos.x > right)
            {
                pos.x = right;
                m_velocity.x = -m_velocity.x;
            }

        }
        if (m_velocity.x < 0.0f)
        {
            //check the left wall
            float left = paddleMoves.WALL_WIDTH + RADIUS;
            if (pos.x < left)
            {
                pos.x = left;
                m_velocity.x = -m_velocity.x;
            }
        }
        // off the bottom of the screen - start over
        //Check for bouncing off the paddle
        Vector3 ballMin = pos - new Vector3(RADIUS, RADIUS, 0f);
        Vector3 ballMax = pos + new Vector3(RADIUS, RADIUS, 0f);
        Vector3 paddleMin = Paddle.transform.position - new Vector3(paddleMoves.HALF_WIDTH, paddleMoves.HALF_HIGHT, 0f);
        Vector3 paddleMax = Paddle.transform.position + new Vector3(paddleMoves.HALF_WIDTH, paddleMoves.HALF_HIGHT, 0f);
        if (AABB.IsOverLap(ballMin, ballMax, paddleMin, paddleMax))
        {
            // hit the paddle
            m_velocity.y = -m_velocity.y;
            pos.y = Paddle.transform.position.y + paddleMoves.HALF_HIGHT + RADIUS;
        }


        /*MATT CODE- for AABB- Check for bouncing off the paddle

        if (m_velocity.y < 0.0f)
        {
            // ball overlaps with y coord of paddle
            if ((pos.y - RADIUS <= Paddle.position.y + FirstPaddle.HALF_HIGHT)
                && (pos.y + RADIUS >= Paddle.position.y - FirstPaddle.HALF_HIGHT)
                )
            {
                if ((pos.x + RADIUS >= Paddle.position.x - FirstPaddle.HALF_WIDTH)
                    && (pos.x - RADIUS <= Paddle.position.x + FirstPaddle.HALF_WIDTH)
                    )
                {
                    pos.y = Paddle.position.y + FirstPaddle.HALF_HIGHT + RADIUS;
                    m_velocity.y = -m_velocity.y;
        */

                    // off the bottom of the screen - start over

                    if (pos.y < 0f)
        {
            SceneManager.LoadScene("Game");
        }

     
        transform.position = pos;

    
    }


          


}
