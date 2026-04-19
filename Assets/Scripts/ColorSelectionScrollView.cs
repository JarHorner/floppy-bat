using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ColorSelectionScrollView : MonoBehaviour
{
    [SerializeField] private List<ColorSelectionButton> buttonsSelected;
    [SerializeField] private GameObject player;
    [SerializeField] private RectTransform contentPanel;
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private TextMeshProUGUI notificationMessage;

    public void DeselectedOtherButtons()
    {
        foreach (ColorSelectionButton button in buttonsSelected)
        {
            button.Animator.SetBool("Selected", false);
        }
    }
    
    public void ConfirmColorChange()
    {
        foreach (ColorSelectionButton button in buttonsSelected)
        {
            if (button.Animator.GetBool("Selected") == true)
            {
                button.Unlock();
                if (!button.IsLocked)
                {
                    MusicPlayer.instance.PlayClick();
                    player.GetComponent<PlayerController>().anim.runtimeAnimatorController = button.PlayerAnim;
                    PlayerPrefs.SetString("SelectedBat", button.name);
                    notificationMessage.text = $"{button.name} has been selected!";
                    notificationMessage.GetComponent<Animator>().Play("FadeIn&Out", -1, 0);
                }
            }
        }
    }

    public void ScrollToMiddle(RectTransform buttonTransform)
    {
        MusicPlayer.instance.PlayClick();

        Canvas.ForceUpdateCanvases();

        contentPanel.anchoredPosition =
            (Vector2)scrollRect.transform.InverseTransformPoint(contentPanel.position)
            - (Vector2)scrollRect.transform.InverseTransformPoint(buttonTransform.position);
    }
}
