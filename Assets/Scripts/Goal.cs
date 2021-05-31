using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

	private void OnTriggerEnter(Collider target)
	{
		BallController ball = target.GetComponent<BallController>();

		if (!ball || GameManager.singleton.GameEnded)
			return;

		Debug.Log("Goal is touched");

		GameManager.singleton.EndGame(true);
	}
}
