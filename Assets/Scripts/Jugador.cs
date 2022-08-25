using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{
    public GameObject _gameManager;

    public float _velNau;

    public GameObject _PrefabProjectil;
    public GameObject _posCano1;

    public TMPro.TextMeshProUGUI _escutsRestantsText;
    private const int MAX_ESCUTS = 3;
    private int _escutsActuals;

    public void InicialitzarNauJugador()
    {
        _escutsActuals = MAX_ESCUTS;
        _escutsRestantsText.text = _escutsActuals.ToString();

        transform.position = new Vector2(0, 0);
        gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float direccioIndicadaX = Input.GetAxisRaw("Horizontal"); // Values: Left: -1, No input: 0, Right: 1.
        float direccioIndicadaY = Input.GetAxisRaw("Vertical");

        Vector2 direccioIndicada = new Vector2(direccioIndicadaX, direccioIndicadaY).normalized;

        MoureNau(direccioIndicada);

        if (Input.GetKeyDown("space"))
        {
            GameObject projectil1 = Instantiate(_PrefabProjectil);
            projectil1.transform.position = _posCano1.transform.position;
        }
    }

    private void MoureNau(Vector2 direccioIndicada)
    {
        // Trobar els límits de la pantalla.
        Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        Vector2 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        minPantalla.x += 0.8f;
        maxPantalla.x -= 0.8f;
        minPantalla.y += 0.8f;
        maxPantalla.y -= 0.8f;

        Vector2 novaPos = transform.position;
        novaPos += direccioIndicada * _velNau * Time.deltaTime;

        novaPos.x = Mathf.Clamp(novaPos.x, minPantalla.x, maxPantalla.x);
        novaPos.y = Mathf.Clamp(novaPos.y, minPantalla.y, maxPantalla.y);

        transform.position = novaPos;
    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "Numero")
        {
            _escutsActuals--;
            _escutsRestantsText.text = _escutsActuals.ToString();

            if (_escutsActuals == 0)
            {
                _gameManager.GetComponent<GameManager>().SetEstatGameManager(GameManager.EstatGameManager.GameOver);
                //Destroy(gameObject);
                gameObject.SetActive(false);
            }
        }
    }
}
