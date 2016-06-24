using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {

	//este controlador va asociado a la camara no al player

	public GameObject player;

	private Vector3 offset;

	void Start ()
	{
		offset = transform.position - player.transform.position;
	}

	void LateUpdate ()
	{
		transform.position = player.transform.position + offset;
	}
}