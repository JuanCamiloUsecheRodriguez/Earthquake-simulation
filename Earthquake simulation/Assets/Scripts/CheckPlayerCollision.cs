using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerCollision : MonoBehaviour {
    /// <summary>
    /// Representa si el jugador se encuentra o no 
    /// adentro del collider.
    /// </summary>
    public bool JugadorAdentro { get; private set; }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        string x = other.gameObject.name; //Obtiene el nombre del objeto que hace la colisión.
        if (x == "HeadCollider") {
            JugadorAdentro = true;
            print("Jugador entró a una mesa");
        }
    }

    private void OnTriggerExit(Collider other) {
        string x = other.gameObject.name; //Obtiene el nombre del objeto que hace la colisión.
        if (x == "HeadCollider") {
            JugadorAdentro = false;
            print("Jugador salió de una mesa");
        }
    }
}
