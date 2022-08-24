using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorNumeros : MonoBehaviour
{
    public GameObject _PrefabNumero;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreaNumero", 1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreaNumero()
    {
        Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject objecteNumero = Instantiate(_PrefabNumero);
        objecteNumero.transform.position = new Vector2(Random.Range(minPantalla.x, maxPantalla.x), maxPantalla.y);
    }
}
