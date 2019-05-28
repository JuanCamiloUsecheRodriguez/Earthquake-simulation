using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectaJugador : MonoBehaviour {

    private Transform Trans;

    private void Awake() {
        Trans = gameObject.transform;
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Detecta si el jugador se encuentra o no bajo alguna de las 3 mesas y
    /// devuelve esa información
    /// </summary>
    /// <returns>boolean que es true si esta bajo mesa, falso sino lo esta</returns>
    public bool EstaBajoMesa() {
        bool SiEsta = false;

        foreach (Transform mesa in Trans) { //Revisa todos los hijos
            if (mesa.GetComponent<CheckPlayerCollision>().JugadorAdentro){
                SiEsta = true;
                print("Si esta el jugador en una mesa");
                break;
            }
        }
        
        return SiEsta;
    }
}
