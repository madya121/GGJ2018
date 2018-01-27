using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
	private Vector3 tempPos;
	public GameObject planet;
	private float distanceBetweenPlanetCamera;

	public float dragSpeed=0.05f;			//0.25
	public float scrollSpeed=2f;		//2
	public float limitX=5f;			//5
	public float limitY=3f;			//3
	public float minZ=-1f;				//-1
	public float maxZ=2f;				//2

  public float delay = 0.07f;

	private float shake = 0f;
	public float shakeAmount = 0.7f;
	private float decreaseFactor = 1f;

	private void Start()
	{
		tempPos = transform.position;
	}

	void Update()
	{
		tempPos.z += Input.GetAxis("Mouse ScrollWheel");
		distanceBetweenPlanetCamera = planet.transform.position.z - this.transform.position.z;

		if (Input.GetMouseButton(2))
		{

			tempPos.x -= Input.GetAxis("Mouse X") * dragSpeed * distanceBetweenPlanetCamera;
			tempPos.y -= Input.GetAxis("Mouse Y") * dragSpeed * distanceBetweenPlanetCamera;

		}

		Vector3 newPosition = new Vector3(
			Mathf.Clamp(tempPos.x,-limitX,limitX),
			Mathf.Clamp(tempPos.y,-limitY,limitY),
			Mathf.Clamp(tempPos.z,minZ,maxZ));

		//shake
		if (Input.GetKey("space"))
		{
			shake = 0.5f;
		}

		if (shake > 0) {
			newPosition += Random.insideUnitSphere * shake * 10;
			shake -= Time.deltaTime * decreaseFactor;

		} else {
			shake = 0.0f;
		}

    transform.position = Vector3.Lerp(transform.position, newPosition, delay);
	}
}
