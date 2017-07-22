using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MapModel
{
	/// <summary>
	/// 横列のCell
	/// </summary>
	public MapCellModel[] mSideCels;
}

[Serializable]
public class MapCellModel {
	public string _0;
	public string _1;
	public string _2;
	public string _3;
	public string _4;
	public string _5;
	public string _6;
	public string _7;
	public string _8;
	public string _9;
	public string _10;

	public string m_0{
		get{ 
			return _0;
		}
	}
	public string m_1{
		get{ 
			return _1;
		}
	}
	public string m_2{
		get{ 
			return _2;
		}
	}
	public string m_3{
		get{ 
			return _3;
		}
	}
	public string m_4{
		get{ 
			return _4;
		}
	}
	public string m_5{
		get{ 
			return _5;
		}
	}
	public string m_6{
		get{ 
			return _6;
		}
	}
	public string m_7{
		get{ 
			return _7;
		}
	}
	public string m_8{
		get{ 
			return _8;
		}
	}
	public string m_9{
		get{ 
			return _9;
		}
	}
	public string m_10{
		get{ 
			return _10;
		}
	}

}
