using TMPro;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    [SerializeField] KillTarget killTarget;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] string currency = "Score:";

    // Update is called once per frame
    void Update()
    {
        updateCurrency();
    }

    public void updateCurrency()
    {
        textMeshProUGUI.text = currency + " " + killTarget.score;
    }
}
