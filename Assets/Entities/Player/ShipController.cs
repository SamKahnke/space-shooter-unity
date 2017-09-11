using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour
{
	public float speed = 8f;

	private float xMin = -5.5f;
	private float xMax = 5.5f;

	void Start ()
	{
		
	}
	
	void Update ()
	{
		MoveShip();
	}

	void MoveShip ()
	{
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		float limitedX = Mathf.Clamp(transform.position.x, xMin, xMax);
		transform.position = new Vector3(limitedX, transform.position.y, transform.position.z);
	}
}
