using UnityEngine;
using System.Collections;

public class HPControl : MonoBehaviour {
	public float m_maxHP;

	private float m_currentHp;
	private bool m_isDead;

	// Use this for initialization
	void Start () 
	{
		m_currentHp = m_maxHP;
		m_isDead = false;
	}
	
	// Update is called once per frame
	public bool IsDead()
	{
		return m_isDead;
	}

	public float GetCurrentHP()
	{
		return m_currentHp;
	}

	public void ApplyDamage(float damage)
	{
		m_currentHp -= damage;
		m_isDead = m_currentHp <= 0f;
		//SendMessage("OnResiveDamage");

		if (m_isDead)
		{
			SendMessage("OnDie");
		}
	}
}
