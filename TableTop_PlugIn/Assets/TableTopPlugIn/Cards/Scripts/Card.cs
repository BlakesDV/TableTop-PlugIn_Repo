using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Card : MonoBehaviour
{
    public CardData data;

    [Header("Referencias de UI")]
    [SerializeField] private Image artworkImage;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private TMP_Text attackText;
    [SerializeField] private TMP_Text defenseText;
    [SerializeField] private TMP_Text costText;

    public void Initialize(CardData d)
    {
        data = d;
        UpdateVisuals();
    }
    private void UpdateVisuals()
    {
        if (data == null) return;

        if (artworkImage != null) artworkImage.sprite = data.artwork;
        if (nameText != null) nameText.text = data.cardName;
        if (descriptionText != null) descriptionText.text = data.description;
        if (attackText != null) attackText.text = data.attack.ToString();
        if (defenseText != null) defenseText.text = data.defense.ToString();
        if (costText != null) costText.text = data.cost.ToString();
    }
}
