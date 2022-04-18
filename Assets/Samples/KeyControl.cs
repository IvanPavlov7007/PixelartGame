

//https://www.reddit.com/r/Unity3D/comments/40c62i/hold_key_to_repeat_with_various_delay_similar_to/


using UnityEngine;
using System.Collections;


[System.Serializable]
public struct GameControls
{
	public KeyCode gamepadPause;
	public KeyCode keyboardPause;
	public bool mouseInverted;
	public KeyCode keyboardCancel;
	public KeyCode gamepadCancel;
	public KeyCode gamepadAction;
	public KeyCode keyboardAction;
	public KeyCode keyboardRight;
	public string gamepadAxisH;
	public KeyCode keyboardLeft;
	public string gamepadAxisV;
    public KeyCode keyboardUp, keyboardDown;
}

public class KeyControl : MonoBehaviour
{
	float pressTimer = 0;
	bool pressBool;
	byte step = 0;

	public GameControls gameSettings;
	public float delay1 = 0.6f, delay2 = 0.2f;

	void Update()
	{
		if (leftCheck || rightCheck)
		{

			switch (step)
			{
				case 0:
					pressBool = true;
					step++;
					break;

				case 1:
					if (!pressBool)
					{
						pressTimer = delay1;
						step++;
					}
					break;

				case 2:
					pressTimer -= Time.deltaTime;
					if (pressTimer < 0f)
						step++;
					break;

				case 3:
					pressBool = true;
					step++;
					break;

				case 4:
					if (!pressBool)
					{
						pressTimer = delay2;
						step++;
					}
					break;

				case 5:
					pressTimer -= Time.deltaTime;
					if (pressTimer < 0f)
						step = 3;
					break;
			}

		}
		else
		{

			pressTimer = 0f;
			step = 0;
		}

		Debug.Log(pressTimer);

	}

	public  bool up
	{
		get
		{
			if (upCheck && pressBool)
			{
				pressBool = false;
				return true;
			}
			else
				return false;
		}
	}

	public  bool right
	{
		get
		{
			if (rightCheck && pressBool)
			{
				pressBool = false;
				Debug.Log("pressed R");
				return true;
			}
			else
				return false;
		}
	}

	public  bool down
	{
		get
		{
			if (downCheck && pressBool)
			{
				pressBool = false;
				return true;
			}
			else
				return false;
		}
	}

	public  bool left
	{
		get
		{
			if (leftCheck && pressBool)
			{
				pressBool = false;
				return true;
			}
			else
				return false;
		}
	}


	public  bool upCheck
	{
		get
		{
			return Input.GetKey(gameSettings.keyboardUp) || Input.GetAxis(gameSettings.gamepadAxisV) < -0.9f;
		}
	}

	public  bool downCheck
	{
		get
		{
			return (Input.GetKey(gameSettings.keyboardDown) || Input.GetAxis(gameSettings.gamepadAxisV) > 0.9f);
		}
	}

	public  bool leftCheck
	{
		get
		{
			return (Input.GetKey(gameSettings.keyboardLeft) || Input.GetAxis(gameSettings.gamepadAxisH) < -0.9f);
		}
	}

	public  bool rightCheck
	{
		get
		{
			return (Input.GetKey(gameSettings.keyboardRight) || Input.GetAxis(gameSettings.gamepadAxisH) > 0.9f);
		}
	}



	public  bool action
	{
		get
		{
			return (Input.GetKey(gameSettings.keyboardAction) || Input.GetKey(gameSettings.gamepadAction) ||
			Input.GetMouseButton(gameSettings.mouseInverted ? 1 : 0));
		}
	}

	public  bool actionUp
	{
		get
		{
			return (Input.GetKeyUp(gameSettings.keyboardAction) || Input.GetKeyUp(gameSettings.gamepadAction) ||
			Input.GetMouseButtonUp(gameSettings.mouseInverted ? 1 : 0));
		}
	}


	public  bool cancel
	{
		get
		{
			return (Input.GetKey(gameSettings.keyboardCancel) || Input.GetKey(gameSettings.gamepadCancel) ||
			Input.GetMouseButton(gameSettings.mouseInverted ? 0 : 1));
		}
	}

	public bool cancelUp
	{
		get
		{
			return (Input.GetKeyUp(gameSettings.keyboardCancel) || Input.GetKeyUp(gameSettings.gamepadCancel) ||
			Input.GetMouseButtonUp(gameSettings.mouseInverted ? 0 : 1));
		}
	}


	public bool pause
	{
		get
		{
			return (Input.GetKey(gameSettings.keyboardPause) ||
			Input.GetKey(gameSettings.gamepadPause));
		}
	}

	public bool pauseUp
	{
		get
		{
			return (Input.GetKeyUp(gameSettings.keyboardPause) ||
			Input.GetKeyUp(gameSettings.gamepadPause));
		}
	}
}