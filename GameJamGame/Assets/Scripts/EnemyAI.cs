using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour {

	public float range;

	private NavMeshAgent navMeshAgent;

	private Vector3 target;

	private PlayerController[] players;

	private enum State
	{
		WANDER = 0,
		CHASE
	};

	private State currentState;
	private State oldState;

	// Use this for initialization
	void Start () {
		navMeshAgent = GetComponent<NavMeshAgent>();
		players = FindObjectsOfType<PlayerController>();

		currentState = State.WANDER;
		oldState = currentState;
	}
	
	// Update is called once per frame
	void Update () {
		DetermineStateAndTarget();

		switch (currentState)
		{
			case State.WANDER:
				Wander();
				break;

			case State.CHASE:
				Chase();
				break;

			default:
				Debug.LogError("Couldn't determine state: EnemyAI.cs (35)");
				break;
		}

		navMeshAgent.destination = target;
	}

	void Wander()
	{
		if (Vector3.Distance(transform.position, target + Vector3.up) > 1f && oldState == State.WANDER)
		{
			return;
		}

		NavMeshTriangulation data = NavMesh.CalculateTriangulation();

		Vector3 vertex = data.vertices[Random.Range(0, data.vertices.Length)];

		NavMeshHit hit;

		if (NavMesh.FindClosestEdge(vertex, out hit, 1 << NavMesh.GetAreaFromName("Walkable")))
		{
			target = hit.position;
		}
		else
		{
			target = vertex;
		}

		oldState = State.WANDER;
	}

	void Chase()
	{
		oldState = State.CHASE;
	}

	void DetermineStateAndTarget()
	{
		currentState = State.WANDER;

		float D = float.MaxValue;

		foreach (PlayerController p in players)
		{
			float d = 0;
			if ((d = Vector3.Distance(transform.position, p.transform.position)) < range)
			{
				currentState = State.CHASE;
				if (d < D)
				{
					D = d;
					target = p.transform.position;
				}
			}
		}
	}
}
