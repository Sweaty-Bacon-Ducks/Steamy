using System;
using UnityEngine;

public static class Utility
{
    /// <summary>
    /// Znajduje GameObject, którego rodzicem jest dany obiekt.
    ///  W przeciwieństwie do GameObject.Find wyszukuje również obiekty, będące nieaktywne. 
    /// </summary>
    /// <param name="name">Nazwa obiektu do znalezienia.</param>
    /// <returns>Referencję do szukanego obiektu lub wyrzuca NullReferenceException w przypadku nie znalezienia obietu.</returns>
    public static GameObject FindObject(this GameObject parent, string name)
    {
        Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in trs)
        {
            if (t.name == name)
            {
                return t.gameObject;
            }
        }
        throw new NullReferenceException("Obiekt nie został znaleziony! Sprawdź czy poprawnie została wpisana jego nazwa.");
    }
}
