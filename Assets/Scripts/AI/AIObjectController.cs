using UnityEngine;
using System.Collections;

public class AIObjectController : MonoBehaviour, IUnitControl
{
	public IUnitControl m_hpControl;
	public IUnitControl m_movementControl;
	public IUnitControl m_attackControl;

	void OnDeath()
	{
		m_hpControl.OnDeath();
		m_movementControl.OnDeath();
		m_attackControl.OnDeath();
	}
}
