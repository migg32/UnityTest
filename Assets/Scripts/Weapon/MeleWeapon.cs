using UnityEngine;
using System.Collections;

public class MeleWeapon : MonoBehaviour
{
	public string[] m_canHitTag;

	private Collider m_hitBoxCollider;

	// Use this for initialization
	void Start()
	{
		m_hitBoxCollider = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	void Attack()
	{

		//.
	}

	void OnTriggerEnter(Collider other)
	{
		string checkHitTargets = System.Array.Find<string>(m_canHitTag, (testString) => {
			return testString == other.tag; });

		if (checkHitTargets != null)
		{

			Debug.Log("Bam!!!");
		}


	}


}
