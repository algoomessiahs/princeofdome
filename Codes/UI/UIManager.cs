using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public Text diamond_Text;

    public Image selection_image;

    public Text diamond_Text_Side;

    public Image[] healthBars;

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("The UI Manager or the instance is == null");
            }
            return instance;
        }
    }

    public void UpdateLives(int lives_remaining)
    {
        for (int i = 0; i <= lives_remaining; i++)
        {
            if (i == lives_remaining)
            {
                healthBars[i].enabled = false;
            }
        }
    }

    public void OpenShop(int gemCount)
    {
        diamond_Text.text = gemCount + "G";
    }

    public void UpdateUnderline(int y_pos, int width)
    {
        selection_image.rectTransform.anchoredPosition = new Vector2(selection_image.rectTransform.anchoredPosition.x, y_pos);
        selection_image.rectTransform.sizeDelta = new Vector2(width, selection_image.rectTransform.sizeDelta.y);
    }

    public void Update_Gem_Count(int count)
    {
        diamond_Text_Side.text = "" + count;
    }

    private void Awake()
    {
        instance = this;
    }

}
