using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject _butoPlay;
    public GameObject _nauJugador;

    public GameObject _generadorNumeros;

    public GameObject _operacioEscritaText;
    public GameObject _gameOverText;

    public enum EstatGameManager
    {
        Inici,
        Jugant,
        GameOver
    }

    private EstatGameManager _estatGameManager;

    // Start is called before the first frame update
    void Start()
    {
        _estatGameManager = EstatGameManager.Inici;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActualitzarEstatGameManager()
    {
        switch(_estatGameManager)
        {
            case EstatGameManager.Inici:

            _butoPlay.SetActive(true);
            _gameOverText.SetActive(false);

            _operacioEscritaText.GetComponent<OperacioEscritaText>().InicialitzaElement();
            
            break;

            case EstatGameManager.Jugant:

            _butoPlay.SetActive(false);
            _nauJugador.GetComponent<Jugador>().InicialitzarNauJugador();
            _generadorNumeros.GetComponent<GeneradorNumeros>().IniciaGeneracioNumeros();

            break;

            case EstatGameManager.GameOver:

            _gameOverText.SetActive(true);
             _generadorNumeros.GetComponent<GeneradorNumeros>().AturarGeneracioNumeros();
             Invoke("PassarAEstatInici", 3f);

            break;
        }
    }

    public void SetEstatGameManager(EstatGameManager estat)
    {
        _estatGameManager = estat;
        ActualitzarEstatGameManager();
    }

    public void IniciarJoc()
    {
        _estatGameManager = EstatGameManager.Jugant;
        ActualitzarEstatGameManager();
    }

    public void PassarAEstatInici()
    {
        SetEstatGameManager(EstatGameManager.Inici);
    }
}
