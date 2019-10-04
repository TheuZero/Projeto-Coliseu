using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusData : ScriptableObject
{
    float maxHp = 10;
    float maxMp = 30;
    float weight = 10;

    public MovementStatusData movementStatusData;
}

public class MovementStatusData{
    public float movementSpeed = 4;
	public float dashSpeed = 12;
	public float runSpeed = 10;

	//timers
	public float jumpSpeed = 4;
	public float jumpMaxTimer = 0.5f;
	public float jumpSquat = 0.1f;
	public float dashTimer = 0f;
}
