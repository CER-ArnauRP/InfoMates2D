using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operacio : MonoBehaviour
{
    public Sprite[] _spritesOperacions = new Sprite[5];

    //private bool _hiHaOperacio = false; // Això ho hauria de tenir el GeneradorOperacions, o potser el GameManager.
    private int _operacioSeleccionada;
    private float _vel;

    // Start is called before the first frame update
    void Start()
    {
        _vel = 2f;

        if (GameObject.Find("OperacioEscritaText").GetComponent<OperacioEscritaText>().getUltimaOperacioEscrita() == "N")
        {
            System.Random aleatori = new System.Random();
            _operacioSeleccionada = aleatori.Next(0, 4); // En la posició 4, hi ha el "=".
            gameObject.GetComponent<SpriteRenderer>().sprite = _spritesOperacions[_operacioSeleccionada];
        }
        else
        {
            // Que només surtin "=" si l'últim que han escrit és alguna operació (diferent de "N").
            _operacioSeleccionada = 4; // El signe de l'igual.
            gameObject.GetComponent<SpriteRenderer>().sprite = _spritesOperacions[_operacioSeleccionada];
        }
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
        if (objecteTocat.tag == "ProjectilJugador")
        {
            GameObject.Find("OperacioEscritaText").GetComponent<OperacioEscritaText>().setUltimaOperacioEscrita(RetornaOperacio());
            //string ultimaOperacioEscrita = GameObject.Find("OperacioEscritaText").GetComponent<OperacioEscritaText>().getUltimaOperacioEscrita();
            /*if (RetornaOperacio() == "=" &&  ultimaOperacioEscrita == "=")
            {
                // Al escriure el segon "="", indiquem que hem acabat de donar resposta, i hem de validar si és correcta.
                //GameObject.Find("GeneradorOperacions").GetComponent<GeneradorOperacions>().AturarGeneracioOperacions();
                GameObject.Find("OperacioEscritaText").GetComponent<OperacioEscritaText>().setUltimaOperacioEscrita("N");
                GameObject.Find("OperacioEscritaText").GetComponent<OperacioEscritaText>().InicialitzaElement();

                // Comprovar si resultat correcte
                // ComprovarResultatCorrecte
            }
            else
            {
                // Si l'últim caràcter escrit ja era una operació, la fórmula no és correcte, i en fem un reset.
                string ultimCaracterEscrit = GameObject.Find("OperacioEscritaText").GetComponent<OperacioEscritaText>().getUltimCaracterEscrit();
                GameObject.Find("OperacioEscritaText").GetComponent<OperacioEscritaText>().setUltimaOperacioEscrita(RetornaOperacio());
                if (ultimCaracterEscrit == "+" || ultimCaracterEscrit == "-" ||
                    ultimCaracterEscrit == "x" || ultimCaracterEscrit == "/" || ultimCaracterEscrit == "=")
                    {
                        // Si han escrit dues operacions seguides, la fórmula no és correcte, i en fem un reset.
                        GameObject.Find("OperacioEscritaText").GetComponent<OperacioEscritaText>().InicialitzaElement();
                    }

                // Actualitzar l'operació mostrada a la UI.
                GameObject.Find("OperacioEscritaText").GetComponent<OperacioEscritaText>().ConcatenaCaracterAlTextFormula(RetornaOperacio());
                GameObject.Find("GeneradorOperacions").GetComponent<GeneradorOperacions>().setOperacioActual(RetornaOperacio());
            }*/
        }

        if (objecteTocat.tag == "ProjectilJugador" || objecteTocat.tag == "Jugador")
        {
            Destroy(gameObject);
        }
    }

    private string RetornaOperacio()
    {
        string operacioSeleccionada = "+";

        switch(_operacioSeleccionada)
        {
            case 0:
            operacioSeleccionada = "+";
            break;

            case 1:
            //operacioSeleccionada = "-";
            operacioSeleccionada = "+";
            break;

            case 2:
            operacioSeleccionada = "x";
            break;

            case 3:
            //operacioSeleccionada = "/";
            operacioSeleccionada = "x";
            break;

            case 4:
            operacioSeleccionada = "=";
            break;
        }

        return operacioSeleccionada;
    }
}
