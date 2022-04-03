using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassInspector : MonoBehaviour
{
    public static ClassInspector Instance;

    public GameObject target;

    public HealthBarView hBar;
    public ManaBarView mBar;
    public TMPro.TextMeshProUGUI iname;
    public Image image;
    public void Setup(GameObject gameObject)
    {
        hBar.health = gameObject.GetComponent<Gameplay.Health>();
        mBar.health = gameObject.GetComponent<Mana>();
        iname.text = gameObject.name;
        image.sprite = gameObject.GetComponent<CharacterRenderer>().Get();
    }

    private void OnValidate()
    {
        if (target)
            Setup(target);
    }

    private void Awake()
    {
        Instance = this;
    }
}
