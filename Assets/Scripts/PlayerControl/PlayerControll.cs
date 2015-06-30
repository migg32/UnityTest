using UnityEngine;
using System.Collections;
using Names;

[RequireComponent(typeof (CharacterController))]

public class PlayerControll : MonoBehaviour 
{
	public float m_speed = 5;
	public Camera m_activeCamera;
	public float m_zoomAccelerate = 10;

	private	CharacterController m_controller;
	private Vector3 m_cameraRelativePosition;

	// Use this for initialization
	void Start() 
	{
		m_controller = GetComponent<CharacterController>();
		m_cameraRelativePosition = transform.position - m_activeCamera.transform.position;
	}

	void FixedUpdate() 
	{
		float inputHorizontal = Input.GetAxis("Horizontal");
		float inputVertical = Input.GetAxis("Vertical");
		Vector3 direction = new Vector3(inputHorizontal, 0, inputVertical).normalized;

		m_controller.SimpleMove(m_speed * direction);


		LookRotation();
		CameraControl();
	}

	private void LookRotation()
	{
		Ray mouseRay = m_activeCamera.ScreenPointToRay(Input.mousePosition);
		RaycastHit mouseRayHit;
		if (Physics.Raycast(mouseRay, out mouseRayHit, m_activeCamera.farClipPlane, Names.Layers.GROUND_LAYER))
		{
			Vector3 mousPos = mouseRayHit.point;
			mousPos.y += transform.position.y;
			transform.LookAt(mousPos);
		}
	}

	private void CameraControl()
	{
		float inputScroll = Input.GetAxis("Mouse ScrollWheel");
		Vector3 newRelativeCamPos = m_cameraRelativePosition - inputScroll * m_activeCamera.transform.forward * m_zoomAccelerate;
		if (newRelativeCamPos.y <= -5 && newRelativeCamPos.y >= -15)
		{
			m_cameraRelativePosition = newRelativeCamPos;
		}

		m_activeCamera.transform.position = transform.position - m_cameraRelativePosition;




	}

}
