using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Show : MonoBehaviour
{
    [SerializeField] GameObject Character;
    [SerializeField] GameObject Fox;
    [SerializeField] GameObject Character_Camera;
    [SerializeField] GameObject Fox_Camera;
    bool isHuman;

   public void Replace(bool value)
   {
    Character.SetActive(value);
    Character_Camera.SetActive(value);
    Fox.SetActive(!value);
    Fox_Camera.SetActive(!value);
   }

   private void Start()
   {
        Replace(isHuman);
   }

   private void Update()
   {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            isHuman = !isHuman;
            Replace(isHuman);
        }
   }
}
