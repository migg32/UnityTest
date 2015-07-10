
using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Camera))]

public class CameraFollowPlayer : MonoBehaviour {

	public Transform m_targetObjectTransform;
	public float m_zoomAccelerate = 10;
	public float m_minZoom = -15;
	public float m_maxZoom = -5;
	public float m_maxShift = 5;
	public float m_smothing = 5f;

	private Vector3 m_cameraRelativePosition;
	private Camera m_thisCamera;
	private float m_maxShiftX;
	// Use this for initialization
	void Start() 
	{
		m_cameraRelativePosition = m_targetObjectTransform.position - transform.position;
		m_thisCamera = GetComponent<Camera>();
		m_maxShiftX = m_maxShift * m_thisCamera.aspect;
	}
	
	// Update is called once per frame
	void FixedUpdate() 
	{
		Zooming();

		Vector3 newPosition = m_targetObjectTransform.position - m_cameraRelativePosition + GetMouseShiftPosition();

		//Debug.Log("mouse = " + posMouse);
		transform.position = Vector3.Lerp(transform.position, newPosition, m_smothing * Time.deltaTime);
	}

	private void Zooming()
	{
		float inputScroll = Input.GetAxis("Mouse ScrollWheel");
		if (inputScroll != 0)
		{
			Vector3 newRelativeCamPos = m_cameraRelativePosition - inputScroll * transform.forward * m_zoomAccelerate;
			if (newRelativeCamPos.y <= m_maxZoom && newRelativeCamPos.y >= m_minZoom)
			{
				m_cameraRelativePosition = newRelativeCamPos;
			}
		}
	}

	private Vector3 GetMouseShiftPosition()
	{
		Vector3 posMouse = Input.mousePosition;
		posMouse.x = m_maxShiftX * (Mathf.Clamp(posMouse.x, 0, Screen.width)/Screen.width - 0.5f);
		posMouse.z = m_maxShift*(Mathf.Clamp(posMouse.y, 0, Screen.height) / Screen.height - 0.5f);
		posMouse.y = 0;

		return posMouse;
	}
}
