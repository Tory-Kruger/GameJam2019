using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(ColorCaster))]
public class EnemyAI : MonoBehaviour {

	public float range;

	[Header("Materials")]
	public Material[] colorMaterials = new Material[2];

	private NavMeshAgent navMeshAgent;

	private PlayerController[] players;

	private ColorCaster colorCaster;

	// Use this for initialization
	void Start () {
		navMeshAgent = GetComponent<NavMeshAgent>();
		colorCaster = GetComponent<ColorCaster>();
		players = FindObjectsOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		// made it to destination
		if (Vector3.Distance(transform.position, navMeshAgent.destination) < 1f)
		{
			NavMeshTriangulation data = NavMesh.CalculateTriangulation();
			Vector3 vertex = data.vertices[Random.Range(0, data.vertices.Length)];
			navMeshAgent.destination = vertex;
		}

		// collision with player
		foreach (PlayerController p in players) {
			if (Vector3.Distance(transform.position, p.transform.position) <= range) {
				colorCaster.playerTag = p.PlayerTag;

				// Change Material
				if(colorMaterials[(int)p.PlayerTag])
					GetComponent<Renderer>().material = colorMaterials[(int)p.PlayerTag];
			}
		}
	}
}
