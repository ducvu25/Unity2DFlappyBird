using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("-------------List button create Hero----------")]
    [SerializeField] float speedCarpet = 2f;
    GameObject listBtn;
    int effectStart;

    // Setting
    bool showSetting;

    GameController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameController.instance;
        showSetting = false;
        CreateBtn();
    }
   /* void LoadInstance()
    {
        controller = GameController.instance;
        CreateBtn();
    }*/
    // Update is called once per frame
    void Update()
    {
        if (GameController.instance != null)
        {
            if (effectStart < controller.GetListHero().Length)
            {
                EffectCreateBtnHero(0);
            }
        }
       /* else
        {
            Invoke("LoadInstance", 0.1f);
        }*/
    }
    void CreateBtn()
    {
        listBtn = transform.GetChild(1).gameObject;
        effectStart = 0;
        for (int i = 0; i < listBtn.transform.childCount; i++)
        {
            if (i < controller.GetListHero().Length)
            {
                //if (i != 0)
                listBtn.transform.GetChild(i).GetChild(0).transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-130 * i, 0, 0);
                listBtn.transform.GetChild(i).GetChild(0).GetChild(1).gameObject.GetComponent<Image>().sprite = controller.GetHero(i).Hub;
                listBtn.transform.GetChild(i).GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<Image>().sprite = controller.GetHero(i).Hub;
                listBtn.transform.GetChild(i).GetChild(0).GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = controller.GetHero(i).Price.ToString();
            }
            else
                listBtn.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    void EffectCreateBtnHero(int i)
    {
        if (i < controller.GetListHero().Length)
        {
            EffectCreateBtnHero(i + 1);
            if (listBtn.transform.GetChild(i).GetChild(0).transform.GetComponent<RectTransform>().anchoredPosition.x < 0)
            {
                listBtn.transform.GetChild(i).GetChild(0).transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(listBtn.transform.GetChild(i).GetChild(0).transform.GetComponent<RectTransform>().anchoredPosition.x + i * speedCarpet, 0, 0);
                if (listBtn.transform.GetChild(i).GetChild(0).transform.GetComponent<RectTransform>().anchoredPosition.x >= 0)
                {
                    listBtn.transform.GetChild(i).GetChild(0).transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
                    effectStart++;
                }
            }
        }
    }
    public void ChooseBtnCreateHero(int i)
    {
        controller.BtnCreate(i);
    }
    public void ChooseSetting(int i)
    {
        switch (i)
        {
            case 0:
                {
                    showSetting = !showSetting;
                    if(showSetting)
                    {
                        transform.GetChild(0).GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("Show");
                    }
                    else
                    {
                        transform.GetChild(0).GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("Hide");
                    }
                    break;
                }
        }
    }
}
