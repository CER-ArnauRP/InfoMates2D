using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OperacioEscritaText : MonoBehaviour
{
    public TMPro.TextMeshProUGUI _punts;
    private int _resultatOperacio = 0;

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
            if (ResultatCorrecte())
            {
                // Sumem punts.
                //Debug.Log("Correcte.");
                /*int puntsActuals = Int32.Parse(_punts.text);// Input string was not in the correct format.
                puntsActuals += _resultatOperacio;
                _punts.text = _resultatOperacio.ToString();*/
            }
            else
            {
                // Baixem escuts.
                //Debug.Log("No correcte.");
                /*int puntsActuals = Int32.Parse(_punts.text);
                puntsActuals -= _resultatOperacio;
                _punts.text = _resultatOperacio.ToString();*/
            }

            // Reiniciem el text de les operacions.
            InicialitzaElement();
        }
        else
        {
            _ultimaOperacioEscrita = caracter;
            ConcatenaCaracterAlTextFormula(caracter);
        }
        
    }

    private bool ResultatCorrecte()
    {
        string textEscrit = gameObject.GetComponent<TMPro.TextMeshProUGUI>().text;
        
        _resultatOperacio = 0;
        string resultatEscrit = "";

        // Trobem si hi ha una suma o una multiplicació, i fem la operació corresponent en cada cas.
        if (textEscrit.IndexOf("+") != -1)
        {
            string[] numerosString = textEscrit.Split("+");
            string[] segonNumeroString = numerosString[1].Split("=");
            resultatEscrit = segonNumeroString[1];

            _resultatOperacio = Int32.Parse(numerosString[0]) + Int32.Parse(segonNumeroString[0]);
        }

        if (textEscrit.IndexOf("x") != -1)
        {
            string[] numerosString = textEscrit.Split("x");
            string[] segonNumeroString = numerosString[1].Split("=");
            resultatEscrit = segonNumeroString[1];
            
            _resultatOperacio = Int32.Parse(numerosString[0]) * Int32.Parse(segonNumeroString[0]);
        }

        if (Int32.Parse(resultatEscrit) == _resultatOperacio)
        {
            return true;
        }
        else
        {
            return false;
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
