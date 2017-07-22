using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using UnityEngine.Events;

public class GameScreenPresenter : MonoBehaviour {

	[SerializeField]
	Image mImage;
	[SerializeField]
	UnityEvent mEvent;

	public string mId{
		get{
			//GameScreen名は座標とリンクしているため、オブジェクト名がID足りうる
			return this.gameObject.name.Replace("(Clone)","");
		}
	}
	public int x{
		get{
			return int.Parse (mId.Split ('_') [0]);
		}
	}
	public int y{
		get{
			return int.Parse (mId.Split ('_') [1]);
		}
	}

	// Use this for initialization
	protected virtual void Start () {
		BaseSceneController.Instance.ExcuteScreenChangeEvent (this);
	}

	[ContextMenu("テストでイベントを実行")]
	public void ExcuteEvent (){
		mEvent.Invoke ();
	}

	
	// Update is called once per frame
	protected virtual void Update () {
		
	}


}
