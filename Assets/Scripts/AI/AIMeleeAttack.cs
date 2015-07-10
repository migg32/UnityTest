using UnityEngine;
using System.Collections;

public class AIMeleeAttack : MonoBehaviour, IUnitControl 
{
	public float m_recharge = 1f;
	public float m_damage = 10f;
	public string m_targetTag = "Player";
	public GameObject m_parent;

	private HPControl m_targetHPControl;
	private bool m_isInRange;
	private float m_time;

	void Awake()
	{
		m_time = 0f;
		m_isInRange = false;
		FindTarget();
	}

	void Update()
	{
		m_time += Time.deltaTime;
		if (m_isInRange && m_time >= m_recharge)
		{
			m_targetHPControl.ApplyDamage(m_damage);
			m_time = 0f;
			if (m_targetHPControl.IsDead())
			{
				m_parent.SendMessage("OnTargetDied");
				this.enabled = false;
			}
			//Debug.Log("ai bam");
		}
	}

	private void FindTarget()
	{
		m_targetHPControl = GameObject.FindGameObjectWithTag(m_targetTag).GetComponent<HPControl>();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == m_targetTag)
		{
			m_isInRange = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == m_targetTag)
		{
			m_isInRange = false;
		}
	}

	void OnDeath()
	{
		this.enabled = false;
	}

	void OnTargetDeath()
	{
		//this.enabled = false;
	}
}
