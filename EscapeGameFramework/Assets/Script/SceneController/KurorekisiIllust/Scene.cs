using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : BaseSceneController {

	// Use this for initialization
	void Start () {
		
	}


	
	// Update is called once per frame
	void Update () {
		
	}

	public override void ExcuteGameEvent (int eventId)
	{
		print ("GameEvent: " + eventId);
	}

	public override void ExcuteItemEvent (int itemId)
	{
		print ("ItemEvent: " + itemId);
	}

	public override void ExcuteScreenChangeEvent (GameScreenPresenter gameScreen)
	{
		print ("ScreenChangeEvent: " + gameScreen);
	}
}
