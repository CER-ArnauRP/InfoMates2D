using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilJugador : MonoBehaviour
{
    private float _vel;

    // Start is called before the first frame update
    void Start()
    {
        _vel = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posProjectil = transform.position;

        posProjectil = new Vector2(posProjectil.x, posProjectil.y + _vel * Time.deltaTime);

        transform.position = posProjectil;

        Vector2 maxPosProjectil = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        if (transform.position.y > maxPosProjectil.y)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "Numero")
        {
            //Debug.Log(objecteTocat.GetComponent<Numero>().getValorNumero());
            Destroy(gameObject);
        }
    }
}
