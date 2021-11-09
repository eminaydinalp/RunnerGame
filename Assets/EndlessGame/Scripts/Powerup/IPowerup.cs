using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public interface IPowerup
{
	float Duration { get;}
	int Index { get; }
	string Name { get; }
	void EndProcess();
	void StartProcess();



}