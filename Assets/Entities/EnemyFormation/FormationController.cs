using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System.Collections;

public class FormationController : MonoBehaviour
{
	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float speed = 4f;

	private float boundaryRightEdge;
	private float boundaryLeftEdge;
	private int direction = -1;
	
	void Start ()
	{
		Camera camera = Camera.main;
		float cameraDistance = transform.position.z - camera.transform.position.z;
		boundaryLeftEdge = camera.ViewportToWorldPoint(new Vector3(0, 0, cameraDistance)).x;
		boundaryRightEdge = camera.ViewportToWorldPoint(new Vector3(1, 1, cameraDistance)).x;
		
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}
	
	void OnDrawGizmos ()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}
	
	void Update ()
	{
		float formationRightEdge = transform.position.x + 0.5f * width;
		float formationLeftEdge = transform.position.x - 0.5f * width;

		if (formationRightEdge > boundaryRightEdge){
			direction = -1;
		}
		if (formationLeftEdge < boundaryLeftEdge){
			direction = 1;
		}

		transform.position += new Vector3(direction * speed * Time.deltaTime, 0, 0);
	}
}