using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameController : MonoBehaviour
{
    [Header("-------------List button create Hero----------")]
    [SerializeField] CharacterSO[] listHero;

    int indexHero;

    bool startGame;

    public static GameController instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        indexHero = -1;
        startGame = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public CharacterSO[] GetListHero()
    {
        return listHero;
    }
    public CharacterSO GetHero(int index)
    {
        return listHero[index];
    }
    public void BtnCreate(int i)
    {
        indexHero = i;
        Mousecontroller.instance.SetSprite(listHero[indexHero].Hub);
    }

    //[Header("Setting")]

    public void Setting(int i)
    {

    }
}
