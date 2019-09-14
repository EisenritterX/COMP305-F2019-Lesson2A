using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanController : MonoBehaviour
{
    public float verticalSpeed = .10f;
    public bool resetToBottomPosition = false;

    private float m_topResetPosition = 9.6f;
    private float m_bottomResetPosition = -4.8f;
    private bool m_isFirstRun = true;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        CheckBounds();
        Move();
    }

    //Reset back to initial position
    void Reset()
    {
        Vector2 resetPosition = new Vector2(0.0f, 0.0f);

        if(m_isFirstRun)
        {
            transform.position = (resetToBottomPosition) ? new Vector2(0.0f, m_bottomResetPosition) : new Vector2(0.0f, m_topResetPosition);
            m_isFirstRun = false;
            print("is first run");
        }
        else
        {
            transform.position = new Vector2(0.0f, m_topResetPosition);
        }

    }

    //Sets the boundary
    void CheckBounds()
    {
        if(transform.position.y <= -19.2f)
        {
            Reset();
        }
    }

    //Move functions
    void Move()
    {
        Vector2 currentPosition = transform.position;
        currentPosition -= new Vector2(0.0f, verticalSpeed);
        transform.position = currentPosition;
    }
}
