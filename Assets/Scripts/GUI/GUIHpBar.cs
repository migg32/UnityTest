using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof (Text))]

public class GUIHpBar : MonoBehaviour {

	public HPControl m_targetHpControl;

	private Text m_text;
	// Use this for initialization
	void Start () 
	{
		m_text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_text.text = m_targetHpControl.GetCurrentHP().ToString();
	}
}
