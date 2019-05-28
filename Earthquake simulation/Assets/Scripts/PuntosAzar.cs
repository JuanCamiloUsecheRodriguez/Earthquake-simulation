using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla el inicio de los objetos de primeros auxilios
/// para que aparezcan en puntos al azar.
/// </summary>
public class PuntosAzar : MonoBehaviour {

    /// <summary>
    /// Los puntos iniciales donde se van a poner los objetos.
    /// Estos son los puntos "aleatorios" donde un objeto puede aparecer.
    /// </summary>
    public Transform[] puntosInicio;

    /// <summary>
    /// Los objetos que van dentro del botiquín.
    /// Estos son los objetos a los que se les va a ajustar su posición incial.
    /// </summary>
    private GameObject[] ObjetosBotiquin;


    //Called before start and always called, even it the object
    //is not enabled
    private void Awake() {
        ObjetosBotiquin = GameObject.FindGameObjectsWithTag("Collectable"); //obtiene los objetos de primeros auxilios
    }

    // Use this for initialization
    void Start () {
        
    }

    /// <summary>
    /// Toma la lista de objetos de primeros auxilios y a cada uno le modifica
    /// su posicion y su rotacion con alguna obtenida al azar de la lista de 
    /// puntos posibles donde pueden aparecer estos objetos.
    /// </summary>
    public void DarPosicionesAleatorias() {

        List<Transform> auxiliar = new List<Transform>(puntosInicio); //Crea una lista dinámica auxiliar para trabajar con las posiciones al azar.
        
        Transform posicionActual = null;
        //Itera sobre cada elemento de primeros auxilios y a cada uno le da una posicion aleatoria.
        for (int i = 0; i < ObjetosBotiquin.Length; i++) {
            int indiceAzar = Random.Range(0, auxiliar.Count); //indice al azar para tomar de la lista de posiciones.
            posicionActual = auxiliar[indiceAzar]; //Toma el objeto de dicho indice.

            // Asigna la posición y rotación del objeto con la obtenida al azar.
            ObjetosBotiquin[i].transform.position = posicionActual.position;
            //ObjetosBotiquin[i].transform.rotation = posicionActual.rotation;            //Removi la rotación porque parece que se ve mejor. Pero se puede descomentar si prefieren
            
            auxiliar.RemoveAt(indiceAzar); // Remueve la posición ya utilizada.
        }

    }

}
