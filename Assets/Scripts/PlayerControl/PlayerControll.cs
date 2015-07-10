using UnityEngine;
using System.Collections;
using Names;

[RequireComponent(typeof (Rigidbody))]

public class PlayerControll : MonoBehaviour 
{
	public float m_speed = 5f;

	private	Rigidbody m_rigidbody;
	//private Vector3 m_cameraRelativePosition;

	// Use this for initialization
	void Awake() 
	{
		m_rigidbody = GetComponent<Rigidbody>();
		//m_cameraRelativePosition = transform.position - m_activeCamera.transform.position;
	}

	void FixedUpdate() 
	{
		MovePlayer();

		LookRotation();
	}

	private void MovePlayer()
	{
		Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
		m_rigidbody.MovePosition(transform.position + m_speed * moveDirection * Time.deltaTime);
	}

	private void LookRotation()
	{
		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit mouseRayHit;
		if (Physics.Raycast(mouseRay, out mouseRayHit, Camera.main.farClipPlane, Names.Layers.GROUND_LAYER))
		{
			Vector3 playerToMouse = mouseRayHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			m_rigidbody.MoveRotation(newRotation);

			//Debug.Log("1");
		}
		else
		{
			Vector3 playerToMouse = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
			playerToMouse.z = playerToMouse.y;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			m_rigidbody.MoveRotation(newRotation);

			//Debug.Log("2");
		}
	}

	void OnDie()
	{
		m_rigidbody.constraints = RigidbodyConstraints.None;
		m_rigidbody.angularDrag = 0f;
		m_rigidbody.drag = 0f;
		m_rigidbody.AddForce(transform.forward * 200);
		this.enabled = false;
	}
}
