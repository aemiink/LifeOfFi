using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fox_Position : MonoBehaviour
{
    //Inspector'da değişkenimizin düzenlemsini sağlar.
    [SerializeField] TMP_Text saveWarning;

    public void foxpositionsave(Vector3 foxPosition)
    {
        PlayerPrefs.SetFloat("posX", foxPosition.x);
        PlayerPrefs.SetFloat("posY", foxPosition.y);
        PlayerPrefs.SetFloat("posZ", foxPosition.z);

        PlayerPrefs.Save();
        saveWarning.text = "Başarıyla oyun kaydedildi!";
        //Invoke fonksiyonu istediğimiz bir fonksiyonu istediğimiz bir zaman çağırmamızı sağlar.
        Invoke("deleteText",2f);

    }

    public void deleteText()
    {
        saveWarning.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        // eger portaldan "Player" etiteketine sahip bir nesne gecerse
        if (other.CompareTag("Player"))
        {
            // Objenin pozisyonuna bakip bu bilgiyi foxpositionsave fonksiyonuna iletelim
            Vector3 pos = other.transform.position;

            foxpositionsave(pos);
             
        }

    }
}
