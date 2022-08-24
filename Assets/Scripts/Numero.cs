using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numero : MonoBehaviour
{

    public Sprite[] _spritesNumeros = new Sprite[10];
    private float _vel;

    private int _valorNumero;

    public int getValorNumero()
    {
        return _valorNumero;
    }

    // Start is called before the first frame update
    void Start()
    {
        _vel = 2f;
        _valorNumero = 0;
        System.Random aleatori = new System.Random();
        _valorNumero = aleatori.Next(0, 10);
        //Debug.Log(_valorNumero);
        gameObject.GetComponent<SpriteRenderer>().sprite = _spritesNumeros[_valorNumero];
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posicio = transform.position;

        posicio = new Vector2(posicio.x, posicio.y - _vel * Time.deltaTime);

        transform.position = posicio;

        Vector2 minPos = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.y < minPos.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "ProjectilJugador" || objecteTocat.tag == "Jugador")
        {
            Destroy(gameObject);
        }
    }
}
