using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjectTriggerClass : MonoBehaviour
{
    //include ref to game man

    public bool examined;
    public bool reading;
    public bool available;

    public TextMeshProUGUI ExamineTXT;
    public TextMeshProUGUI ObjectTXT;
    public GameObject Panel;
    public string ObjectNarrate;


    void Start()
    {
        ExamineTXT.gameObject.SetActive(false);
        Panel.gameObject.SetActive(false);
        ObjectTXT.gameObject.SetActive(false);
    }

    //currently working on switching read bool off whilst keeping examine option on!
    
    void Update()
    {
       if (available)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                reading = true;
            }
        }
      
       if (reading)
        {
            ExaminingUI();
        }
    }

    void ExaminingUI()
    {
        //freeze bool in GameMan == true to freeze player movement n stuff
        ExamineTXT.gameObject.SetActive(false);
        ObjectTXT.gameObject.SetActive(true);
        ObjectTXT.text = ObjectNarrate.ToString();
        examined = true;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            reading = false;
            ObjectTXT.text = "";
            ObjectTXT.gameObject.SetActive(false);
            Panel.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collison)
    {
        if (collison.gameObject.tag.Equals("Player"))
        {
            ExamineTXT.gameObject.SetActive(true);
            Panel.gameObject.SetActive(true);
            print("I am available");
            available = true;
        }
    }

    private void OnTriggerExit(Collider collison)
    {
        if (collison.gameObject.tag == "Player")
        {
            print("I am NOT available");
            available = false;
            ExamineTXT.gameObject.SetActive(false);
            Panel.gameObject.SetActive(false);
        }
    }
}
