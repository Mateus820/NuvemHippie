using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSequence : MonoBehaviour {

	//Variaveis;
    public int part, showEvent;

    public bool RunPart { get; set; }
    public bool RunEvent { get; set; }
    public int Event { get; set; }
    public int Part { get; set; }
	public TypeWritter typeWritter;

    void Start()
    {
		Begin();
    }

    public void Begin()
    {
		//Set values;
		Part = part;
		Event = showEvent;

		RunEvent = true;
        RunPart = true;	
	}
    void Update()
    {
        part = Part;

        if (RunPart && Part == 1)
        {
            if(RunEvent && Event == 0){
                //Empty Event;
            }
            else if (RunEvent && Event == 1){
                Type("Introduction");
            }
        	RunPart = false;
    	}
	}
	private void Type(string fileName = ""){
		typeWritter.Type(@"Dialogues/" + fileName + ".txt");
	}
}
