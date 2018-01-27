using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
	private Vector3 tempPos;
	
	public float dragSpeed=0.25f;			//0.25
	public float scrollSpeed=2f;		//2
	public float limitX=5f;			//5
	public float limitY=3f;			//3
	public float minZ=-1f;				//-1
	public float maxZ=2f;				//2

	private float shake = 0f;
	private float shakeAmount = 0.7f;
	private float decreaseFactor = 1f;
	
	private void Start()
	{
		tempPos = transform.position;
	}

	void Update()
	{
		tempPos.z += Input.GetAxis("Mouse ScrollWheel");

		
		if (Input.GetMouseButton(2))
		{

			tempPos.x -= Input.GetAxis("Mouse X") * dragSpeed;
			tempPos.y -= Input.GetAxis("Mouse Y") * dragSpeed;

		}
		
		transform.position = new Vector3(
			Mathf.Clamp(tempPos.x,-limitX,limitX),
			Mathf.Clamp(tempPos.y,-limitY,limitY),
			Mathf.Clamp(tempPos.z,minZ,maxZ));
		
		//shake
		if (Input.GetKey("space"))
		{
			shake = 0.5f;
		}
		
		if (shake > 0) {
			transform.localPosition = Random.insideUnitSphere * shakeAmount;
			shake -= Time.deltaTime * decreaseFactor;
 
		} else {
			shake = 0.0f;
		}
	}
}
