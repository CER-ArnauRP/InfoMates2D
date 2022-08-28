using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorOperacions : MonoBehaviour
{
    //private string _operacioActual = "N";

    public GameObject _PrefabOperacio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void CreaOperacio()
    {
        Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject objecteOperacio = Instantiate(_PrefabOperacio);
        objecteOperacio.transform.position = new Vector2(Random.Range(minPantalla.x, maxPantalla.x), maxPantalla.y);
    }

    public void AturarGeneracioOperacions()
    {
        CancelInvoke("CreaOperacio");
    }

    public void IniciaGeneracioOperacions()
    {
        //_operacioActual = "N";
        InvokeRepeating("CreaOperacio", 3f, 4f);
    }

    /*public void setOperacioActual(string operacio)
    {
        _operacioActual = operacio;
    }

    public string getOperacioActual()
    {
        return _operacioActual;
    }*/
}
