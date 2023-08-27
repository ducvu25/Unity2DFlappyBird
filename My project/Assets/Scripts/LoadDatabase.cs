using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDatabase : MonoBehaviour
{
    List<CharacterSO> listHero;
    List<CharacterSO> listEnemy;
    public void LoadData()
    {
        listHero = new List<CharacterSO>();
        listEnemy = new List<CharacterSO>();

        CharacterSO[] load1 = Resources.LoadAll<CharacterSO>("Hero");
        foreach(CharacterSO item in load1)
        {
            listHero.Add(item);
        }
        CharacterSO[] load2 = Resources.LoadAll<CharacterSO>("Enemy");
        foreach(CharacterSO item in load2)
        {
            listEnemy.Add(item);
        }
    }
    CharacterSO SearchHero(string id)
    {
        foreach(CharacterSO item in listHero)
        {
            if(item.Id == id)
                return item;
        }
        return null;
    }
    CharacterSO SearchEnemy(string id)
    {
        foreach (CharacterSO item in listEnemy)
        {
            if (item.Id == id)
                return item;
        }
        return null;
    }
}
