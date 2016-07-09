﻿//ActorController.cs
//Created by Aaron C Gaudette on 05.07.16
//Example Actor type with separate head transform

using UnityEngine;

public class ActorController : Holojam.Actor{
	public Transform head;
	
	protected override void Update(){
		if(view.IsTracked){
			transform.position=view.RawPosition;
			if(head!=null){
				head.localPosition=Vector3.zero;
				head.rotation=view.RawRotation;
			}
			else Debug.LogWarning("ActorController: No head found for "+name+" ("+(index+1)+")");
		}
	}
	public override Vector3 eyes{
		get{return transform.position;}
	}
	public override Quaternion orientation{
		get{return head!=null?head.rotation:Quaternion.identity;}
	}
	
	//Assign color of geometry with Motif tag
	public override void ApplyMotif(){
		if(Application.isPlaying)
			foreach(Renderer r in GetComponentsInChildren<Renderer>())
				if(r.gameObject.tag=="Motif")r.material.color=motif;
	}
}