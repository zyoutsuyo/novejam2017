using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindwManager : SingletonMonoBehaviour<WindwManager> {

	[SerializeField]
	StoryWindw mStoryWindwPrefab;
	StoryWindw mStoryWindw;
	[SerializeField]
	Canvas mCanvas;

	public bool IsOpenStoryWindow{
		get{
			return mStoryWindw != null;
		}
	}

	public StoryWindw OpenStoryWindw(List<StoryModel> masterStoryData){
		mStoryWindw = PrefabFolder.InstantiateTo<StoryWindw> (mStoryWindwPrefab, mCanvas.transform);
		mStoryWindw.Init (masterStoryData,()=>{
			mStoryWindw = null;
		});
		return mStoryWindw;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
