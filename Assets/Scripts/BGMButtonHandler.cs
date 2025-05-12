using UnityEngine;
using UnityEngine.UI;

public class BGMButtonHandler : MonoBehaviour
{
    private Button btn;
    private BGM bgm;

    void Awake()
    {
        btn = GetComponent<Button>();
    }

    void Start()
    {
        bgm = FindObjectOfType<BGM>();
        if (bgm == null)
        {
            btn.interactable = false;
            return;
        }

        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(bgm.ToggleMusic);
    }
}
