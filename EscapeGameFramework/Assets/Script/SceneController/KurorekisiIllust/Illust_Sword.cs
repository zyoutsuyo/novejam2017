using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Illust_Sword : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void Click () {
		WindwManager.Instance.OpenStoryWindw (
			GameManager.Instance.MasterStoryData.Where (m => 26 <= m.id && m.id <= 28).ToList ()
		).SetEndCallBack (() => {
			GameManager.Instance.AddPlayerItem (1);
		});
	}
}
