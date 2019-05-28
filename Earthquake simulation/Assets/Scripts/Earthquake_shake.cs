using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthquake_shake : MonoBehaviour {

    /// <summary>
    /// Fuerza que tendrá el terremoto más débil.
    /// </summary>
    [Range(0.0f, 0.05f)]
    public float fuerzaMini = 0.01f;

    /// <summary>
    /// Fuerza que tendrá el terremoto más potente.
    /// </summary>
    [Range(0.0f, 0.05f)]
    public float fuerzaMax = 0.02f;

    /// <summary>
    /// Velocidad de movimiento para los terremotos.
    /// Es mejor dejar esta opción baja para ambos terremotos.
    /// </summary>
    [Range(0.0f, 0.03f)]
    public float velocidad = 0.01f;

    /// <summary>
    /// Posición inicial de que???
    /// </summary>
    Vector3 startingPos;
    /// <summary>
    /// Particulas de polvo
    /// </summary>
    public ParticleSystem dust;

    public GameObject dirLight;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

    }

    /// <summary>
    /// Genera al azar un -1 o un 1. De esta forma se puede utilizar
    /// su resultado para cambiar el signo de un número al azar.
    /// </summary>
    /// <returns>-1 o 1</returns>
    int Sign() {
        float r = Random.Range(0f,1f);
        return (r >= 0.5? -1 : 1);
    }

    /// <summary>
    /// Causa que el objeto tiemble en ese frame con un terremoto pequeño.
    /// Al llamarlo se hace vibrar al objeto con la configuración más suave 
    /// de terremoto.
    /// </summary>
    public void CorrerPequeño() {
        Earthquake(fuerzaMini);
    }

    /// <summary>
    /// Causa que el objeto tiemble en ese frame con un terremoto fuerte.
    /// Al llamarlo se hace vibrar al objeto con la configuración más fuerte 
    /// de terremoto.
    /// </summary>
    public void CorrerFuerte() {
        Earthquake(fuerzaMax);
        //Llamada a las partículas
        dust.Play();
        //inicia la animación de caida de los objetos no asegurados.
        GameObject[] unsecuredObjs = GameObject.FindGameObjectsWithTag("Unsecured");
        StartCoroutine(Waiter(unsecuredObjs));
        StartCoroutine(WaiterLight());
        /*
        foreach (GameObject unsecured in unsecuredObjs)
        {
            unsecured.GetComponent<Animator>().SetBool("Earthquake", true);
            StartCoroutine(waiter());
        }*/
    }

    public void Detenerse()
    {
        Earthquake(0);
    }

    IEnumerator Waiter(GameObject[] gameObjects)
    {
        foreach (GameObject unsecured in gameObjects)
        {
            unsecured.GetComponent<Animator>().SetBool("Earthquake", true);
            yield return new WaitForSeconds(1);
            
        }
    }
    IEnumerator WaiterLight()
    {
        dirLight.SetActive(false);
        yield return new WaitForSeconds(2);
        dirLight.SetActive(true);
        yield return new WaitForSeconds(2);
        dirLight.SetActive(false);
        yield return new WaitForSeconds(3);
        dirLight.SetActive(true);
        yield return new WaitForSeconds(2);
        dirLight.SetActive(false);
    }

    /// <summary>
    /// Funcion para cambiar la posicion del jugador en 
    /// cada calculo de frames y de esta forma simular un terremoto
    /// en la cara del VR. El método necesita un numero de punto 
    /// flotante para representar la fuerza que el terremoto 
    /// va a tener.
    /// </summary>
    /// <param name="fuerza">fuerza con la que el terremoto se ejecuta. Entre 0f y 0.05f</param>
    private void Earthquake(float fuerza) {
        startingPos.x = transform.position.x;
        startingPos.y = transform.position.y;
        startingPos.z = transform.position.z;

        startingPos.x += Sign() * (Mathf.Sin(Time.time * velocidad) * fuerza);
        startingPos.y += Sign() * 0; //Es mejor no mover el eje Y del jugador.
        startingPos.z += Sign() * (Mathf.Sin(Time.time * velocidad) * fuerza);

        transform.position = startingPos;
    }


}
