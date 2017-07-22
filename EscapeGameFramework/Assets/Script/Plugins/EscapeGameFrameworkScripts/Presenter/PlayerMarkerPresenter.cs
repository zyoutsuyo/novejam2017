using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerDirection{
	UP,
	DOWN,
	LEFT,
	RIGHT,
}

public class PlayerMarkerPresenter : MonoBehaviour {
	
	PlayerPresenter mPlayerPresenter;
	[SerializeField]
	Image mImage;

	Vector3 UpRotation = new Vector3(0,0,0);
	Vector3 DownRotation = new Vector3(0,0,-180);
	Vector3 LeftRotation = new Vector3(0,0,-270);
	Vector3 RightRotation = new Vector3(0,0,-90);

	//PlayerDirection mCurrentDirection = PlayerDirection.UP;

	public void SetPlayerMarkerDirection(PlayerDirection direction){
		GameManager.Instance.Player.SetCurrentDirection (direction);
		switch (direction) {
		case PlayerDirection.UP:
			this.transform.eulerAngles = UpRotation;
			break;
		case PlayerDirection.DOWN:
			this.transform.eulerAngles = DownRotation;
			break;
		case PlayerDirection.LEFT:
			this.transform.eulerAngles = LeftRotation;
			break;
		case PlayerDirection.RIGHT:
			this.transform.eulerAngles = RightRotation;
			break;
		default:
			break;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
