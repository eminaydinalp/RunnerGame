using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IPowerup
{
	float Duration { get; }
	void EndProcess();
	void StartProcess();


}