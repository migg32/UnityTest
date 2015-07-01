using UnityEngine;
using System.Collections;

[RequireComponent(typeof (NavMeshAgent))]

public class FollowPlayer : MonoBehaviour
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
}
