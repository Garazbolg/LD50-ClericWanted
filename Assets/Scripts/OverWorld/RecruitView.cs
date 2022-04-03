using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecruitView : MonoBehaviour
{
    public Image image;
    public TMPro.TextMeshProUGUI textName;

    private CharacterProfile profile;
    private RecuitmentManager manager;

    public void Setup(CharacterProfile profile, RecuitmentManager manager)
    {
        this.profile = profile;
        image.sprite = profile.sprite;
        textName.text = profile.name;
        this.manager = manager;
    }

    public void Recruit()
    {
        WorldMain.party.Add(profile);
        manager.Setup();
    }
}
