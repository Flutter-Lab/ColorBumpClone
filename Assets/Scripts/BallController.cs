using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float thrust = 150f;
    private Rigidbody rb;
    [SerializeField] private float wallDistance = 5f;
    [SerializeField] private float minCamDistance = 5f;


    private Vector2 lastMousePos;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameManager.singleton.StartGame();

    }

    

    void Update()
    {
        Vector2 deltaPos = Vector2.zero;

		if (Input.GetMouseButton(0))
		{
            Vector2 currentMousePos = Input.mousePosition;
            if (lastMousePos == Vector2.zero)      // Initial value of lastMousePos = 0f;
                lastMousePos = currentMousePos;

            deltaPos = currentMousePos - lastMousePos;
            lastMousePos = currentMousePos;

            Vector3 force = new Vector3(deltaPos.x, 0, deltaPos.y) * thrust;
            rb.AddForce(force);
		}
		else
		{
            lastMousePos = Vector2.zero;
		}
    }

	private void FixedUpdate()
	{
        if (GameManager.singleton.GameEnded)
            return;

		if (GameManager.singleton.GameStarted)
		{
            rb.MovePosition(transform.position + Vector3.forward * 5 * Time.fixedDeltaTime);
		}
	}


	private void LateUpdate()
	{
        Vector3 pos = transform.position;

        if(transform.position.x < -wallDistance)
		{
            pos.x = -wallDistance;
		}
        else if(transform.position.x > wallDistance)
		{
            pos.x = wallDistance;
		}

        if(transform.position.z < Camera.main.transform.position.z + minCamDistance)
		{
            pos.z = Camera.main.transform.position.z + minCamDistance;
		}

        transform.position = pos;
	}

	private void OnCollisionEnter(Collision target)
	{
        if (GameManager.singleton.GameEnded)
            return;

        if (target.gameObject.tag == "Death")
		{
            GameManager.singleton.EndGame(false);   
		}
	}
}
