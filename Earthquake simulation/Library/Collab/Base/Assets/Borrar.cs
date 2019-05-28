using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borrar : MonoBehaviour {

    private int Meh, Meeh, Meeeh, Meeeeh;

    void Start () {
		
	}
	
	void Update () {
        Meh++;

        if (Meh > 60) {
            Meh = 0;
            Meeh++;
        }

        if (Meeh > 60)
        {
            Meeh = 0;
            Meeeh++;
        }

        if (Meeeh > 60)
        {
            Meeh = 0;
            Meeeeh++;
        }
        print("El número raro ese actual es: " + Meeeeh.ToString());
	}
}
