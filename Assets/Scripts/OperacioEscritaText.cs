using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OperacioEscritaText : MonoBehaviour
{
    private string _ultimaOperacioEscrita = "N";
    private string _ultimCaracterEscrit = "0";

    public string getUltimCaracterEscrit()
    {
        return _ultimCaracterEscrit;
    }

    public void setUltimCaracterEscrit(string caracter)
    {
        _ultimCaracterEscrit = caracter;
        ConcatenaCaracterAlTextFormula(_ultimCaracterEscrit);
    }

    public string getUltimaOperacioEscrita()
    {
        return _ultimaOperacioEscrita;
    }

    public void setUltimaOperacioEscrita(string caracter)
    {
        if (UltimCaracterEscritEsOperacio()) // I ara estan escrivint una altra operació.
        {
            // Fórmula incorrecta: reiniciem.
            InicialitzaElement();
            return;
        }

        // Comprovem si han acabat d'escriure un resultat 
        // (havent posat un "=", quan l'operació escrita anteriorment, també era un "=").
        if (_ultimaOperacioEscrita == "=" && caracter == "=")
        {
            // Comprovem si l'operació és correcta.

            // Reiniciem el text de les operacions.
            InicialitzaElement();
        }
        else
        {
            _ultimaOperacioEscrita = caracter;
            ConcatenaCaracterAlTextFormula(caracter);
        }
        
    }

    private bool UltimCaracterEscritEsOperacio()
    {
        if (_ultimCaracterEscrit == "+" || _ultimCaracterEscrit == "x" || _ultimCaracterEscrit == "=")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ConcatenaCaracterAlTextFormula(string nouCaracter)
    {
        //Debug.Log(nouCaracter);
        
        _ultimCaracterEscrit = nouCaracter;

        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text += nouCaracter;
        
        /*if (gameObject.GetComponent<TMPro.TextMeshProUGUI>().text == "0")
        {
            gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = nouCaracter;
        }
        else
        {
            gameObject.GetComponent<TMPro.TextMeshProUGUI>().text += nouCaracter;
        }*/
    }

    public void InicialitzaElement()
    {
        _ultimaOperacioEscrita = "N";
        

        System.Random aleatori = new System.Random();
        int valorNumero = aleatori.Next(1, 10); // Número aleatori entre 1 i 9.

        _ultimCaracterEscrit = valorNumero.ToString();
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = valorNumero.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        InicialitzaElement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
