using UnityEngine;
using System.Collections;

[RequireComponent(typeof (CharacterController))]

public class PlayerControll : MonoBehaviour 
{
	public float m_speed = 5;
	public Camera m_activeCamera;

	private	CharacterController m_controller;

	// Use this for initialization
	void Start() 
	{
		m_controller = GetComponent<CharacterController>();
	}

	void FixedUpdate() 
	{
		float inputHorizontal = Input.GetAxis("Horizontal");
		float inputVertical = Input.GetAxis("Vertical");
		Vector3 direction = new Vector3(inputHorizontal, 0, inputVertical).normalized;

		m_controller.SimpleMove(m_speed * direction);

		LookRotation();
	}

	private void LookRotation()
	{
		//float cameraDistance;
		//Vector3 mousePos = m_activeCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, m_activeCamera.transform.position.y));
		Ray mousePos = m_activeCamera.ScreenPointToRay(Input.mousePosition);

		mousePos.g
		//transform.LookAt(mousePos);
		Debug.DrawRay(mousePos.origin, mousePos.direction*1000);
	}

}
