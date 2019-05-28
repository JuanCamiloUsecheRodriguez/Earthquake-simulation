using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class securingScript : MonoBehaviour {
    /*
     * Este array sera usado para mirar si un objeto es asegurable de cierta manera o no. el float que se guarda en el indice
     * indica cuantos puntos se le da por el metodo de aseguramiento donde:
     * 0 = 0 puntos
     * 1 = 250 puntos
     * 2 = 500 puntos
     * y donde los indices:
     * elem 0 = velcro
     * elem 1 = putty
     * elem 2 = closed hook
     * elem 3 = straps
     * elem 4 = non slip mat
     * elem 5 = cinta adhesiva
     */
    public float[] pointsToWin = new float[6];
    /*
     * Este array sera usado para mirar si un objeto fue asegurado de cierta manera. el indice es 1 si se aseguro con el metodo
     * y 0 si no y donde el mapping de los indices es el mismo que para el arreglo anterior
     */
    private float[] secure = new float[6];

    private Outline outline;
    private bool eartquake;
    Animator m_Animator;

    private void Awake()
    {
        outline = gameObject.GetComponent<Outline>();
        m_Animator = gameObject.GetComponent<Animator>();
        eartquake = false;
    }

    // Use this for initialization
    void Start ()
    {
        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineWidth = 3f;
        changeOutlineColor(Color.grey);
    }
    // Update is called once per frame
    void Update()
    {
        if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Falling") &&
   m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            gameObject.tag = "Fallen";
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (!eartquake) {
            string otherTag = other.gameObject.tag;
            if (otherTag == "Velcro")
            {
                secure[0] = 1;
                Debug.Log("secured with velcro");
                changeOutlineColor(Color.cyan);
            }
            else if (otherTag == "Putty")
            {
                secure[1] = 1;
                Debug.Log("secured with putty");
                changeOutlineColor(Color.cyan);
            }
            else if (otherTag == "ClosedHook")
            {
                secure[2] = 1;
                Debug.Log("secured with closedHook");
                changeOutlineColor(Color.cyan);
            }
            else if (otherTag == "Straps")
            {
                secure[3] = 1;
                Debug.Log("secured with straps");
                changeOutlineColor(Color.cyan);
            }
            else if (otherTag == "NonSlipMat")
            {
                secure[4] = 1;
                Debug.Log("secured with non slip mat");
                changeOutlineColor(Color.cyan);
            }
            else if (otherTag == "CintaAdhesiva")
            {
                secure[5] = 1;
                Debug.Log("secured with cintaAdhesiva");
                changeOutlineColor(Color.cyan);
            }
        }
    }

    void changeOutlineColor(Color newColor)
    {
        outline.OutlineColor = newColor;
    }

    public void Restart()
    {
        eartquake = false;
        secure = new float[6];
        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineWidth = 3f;
        changeOutlineColor(Color.grey);
    }
    public void EarthquakeResult()
    {
        eartquake = true;
        float points = 0;
        for (int i = 0; i < pointsToWin.Length; i++)
        {
            points += pointsToWin[i]*secure[i]*250;
        }
        if (points == 0)
        {
            changeOutlineColor(Color.red);
            gameObject.tag = "Unsecured";
        }
        else if(points >= 500)
        {
            changeOutlineColor(Color.green);
        }
        else
        {
            changeOutlineColor(Color.yellow);
        }
        outline.OutlineWidth = 5f; //Engrosa la linea
        Debug.Log("point securing: " + points);
        GameObject.FindGameObjectWithTag("Game").SendMessage("IncreasePointsSecuring", points);
    }

}
