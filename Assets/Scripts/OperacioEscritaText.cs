using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OperacioEscritaText : MonoBehaviour
{
    public void setOperacioText(string nouNumero)
    {
        //Debug.Log(nouNumero);

        if (gameObject.GetComponent<TMPro.TextMeshProUGUI>().text == "0")
        {
            gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = nouNumero;
        }
        else
        {
            gameObject.GetComponent<TMPro.TextMeshProUGUI>().text += nouNumero;
        }
    }

    public void InicialitzaElement()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "0";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
