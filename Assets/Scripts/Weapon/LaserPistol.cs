using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(LineRenderer))]

public class LaserPistol : MonoBehaviour {

	public float m_recharge = 1f;
	public float m_damage = 10f;
	public float m_range = 50f;

	private float m_time;
	private ParticleSystem m_particleSystem;
	private LineRenderer m_lineRenderer;
	private bool m_isFireing;
	private float m_beamTime = 0.2f;

	
	void Awake()
	{
		m_time = 0f;
		m_isFireing = false;
		m_particleSystem = GetComponent<ParticleSystem>();
		m_lineRenderer = GetComponent<LineRenderer>();
	}
	
	void Update()
	{
		m_time += Time.deltaTime;
		if (Input.GetButton("Fire1") && m_time >= m_recharge)
		{
			Fire();
			m_time = 0f;
			//Debug.Log("ai bam");
		}

		if (m_isFireing && m_time >= m_beamTime)
		{
			m_lineRenderer.enabled = false;
			m_isFireing = false;
		}
	}

	void Fire()
	{
		m_isFireing = true;
		m_particleSystem.Stop();
		m_particleSystem.Play();

		Ray laserRay = new Ray(transform.position, transform.forward);

		m_lineRenderer.SetPosition(0, transform.position);
		RaycastHit laserRayHit;

		if (Physics.Raycast(laserRay, out laserRayHit, m_range, Names.Layers.SHOOTABLE_LAYERS))
		{
			m_lineRenderer.SetPosition(1, laserRayHit.point);
			HPControl targetHPControl = laserRayHit.transform.GetComponent<HPControl>();
			if (targetHPControl)
			{
				targetHPControl.ApplyDamage(m_damage);
			}
		}
		else
		{
			m_lineRenderer.SetPosition(1, laserRay.origin + laserRay.direction * m_range);
		}

		m_lineRenderer.enabled = true;
	}
}
