using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;

    public GameObject buy_popup;

    Player player;

    int current_selected_item;

    int current_item_cost;

    public int fire_sowrd_cost = 100;
    public int boots_cost = 200;
    public int key_cost = 500;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<Player>();

            if (player != null)
            {
                UIManager.Instance.OpenShop(player.diamonds);
            }

            shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item_index)
    {
        switch (item_index)
        {
            case 0:
                UIManager.Instance.UpdateUnderline(y_pos: 238, width: 600);
                current_selected_item = 0;
                current_item_cost = fire_sowrd_cost;
                break;

            case 1:
                UIManager.Instance.UpdateUnderline(y_pos: 23, width: 500);
                current_selected_item = 1;
                current_item_cost = boots_cost;
                break;

            case 2:
                UIManager.Instance.UpdateUnderline(y_pos: -160, width: 700);
                current_selected_item = 2;
                current_item_cost = key_cost;
                break;
        }
    }

    public void ButItem()
    {
        if (player.diamonds >= current_item_cost)
        {
            player.diamonds -= current_item_cost;
            UIManager.Instance.OpenShop(GameManager.InstanceGameManager.Player.diamonds);


            if (current_selected_item == 2)
            {
                GameManager.InstanceGameManager.hasKeyToCastle = true;
                //player.diamonds -= current_item_cost;
            }
        }
        else
        {
            buy_popup.SetActive(true);
            //shopPanel.SetActive(false);
        }
    }

    public void ClosePopUp(GameObject whatYouWantToClose)
    {
        whatYouWantToClose.SetActive(false);
    }

    public void EnablePopUp(GameObject whatToOpen)
    {
        buy_popup.SetActive(false);
        whatToOpen.SetActive(true);
    }
}
