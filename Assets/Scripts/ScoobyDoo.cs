using UnityEngine;
using System.Collections;

public class ScoobyDoo {

	private static ScoobyDoo instance = null;
	public HUDController HumanDescription = null;

	private int fear = 0;
	private int treasure = 0;
	private int time = 00;
    private bool hasKey = false;



	private ScoobyDoo(){
		//private default constructor
	}

	public static ScoobyDoo Instance{
		//public getter will either create a new player or return the one that is already available
		get{ 
			if (instance == null) {
				instance = new ScoobyDoo ();
			}
			return instance;
		}
	}

	public int Treasure{
		get{ 
			return treasure;
		}
		set{ 
			treasure = value;
			//Update Treasure here
		}
	}

	public int Time{
		get{ 
			return time;
		}
		set{ 
			time = value;
			if (time == 0) {
				//Gameover
			}
		}
	}

	public int Fear{
		get{ 
			return fear;
		}
		set{ 
			fear = value;
			if (fear <= 0) {
				//Gameover
			}
		}
	}

    public bool HasKey
    {
        get
        {
            return hasKey;
        }

        set
        {
            hasKey = value;
        }
    }
}
