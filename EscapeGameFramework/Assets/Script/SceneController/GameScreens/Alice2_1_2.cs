using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Alice2_1_2 : GameScreenEventBase {

	[SerializeField]
	Image mRabbit;

	public void TapEntrance(){
		WindwManager.Instance.OpenStoryWindw (
			GameManager.Instance.MasterStoryData.Where(m=>m.id == 1).ToList()
		);
	}

	public override void ExcuteEvent ()
	{
		mRabbit.gameObject.SetActive (true);
		//throw new System.NotImplementedException ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
