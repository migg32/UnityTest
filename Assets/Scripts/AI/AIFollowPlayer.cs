using UnityEngine;
using System.Collections;

[RequireComponent(typeof (NavMeshAgent))]

public class AIFollowPlayer : MonoBehaviour, IUnitControl
{
	public string m_targetTag;
	private Transform m_targetTranform;
	private NavMeshAgent m_navMeshAgent;
	// Use this for initialization
	void Awake()
	{
		m_targetTranform = GameObject.FindGameObjectWithTag(m_targetTag).transform;
		m_navMeshAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update()
	{
		m_navMeshAgent.SetDestination(m_targetTranform.position);
	}

	void OnDeath()
	{
		Rigidbody rigidbody = GetComponent<Rigidbody>();
		rigidbody.constraints = RigidbodyConstraints.None;
		rigidbody.angularDrag = 0f;
		rigidbody.drag = 0f;
		rigidbody.AddForce(transform.forward * 200);
		m_navMeshAgent.enabled = false;
		this.enabled = false;
	}

	void OnTargetDeath()
	{
		m_navMeshAgent.enabled = false;
		this.enabled = false;
	}
}
