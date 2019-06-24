using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Abilities
{
	public class AbilityGUI : MonoBehaviour
    {
		[Header("Icon")]
        [SerializeField] private Image icon;
		
		[Header("Reload")]
        [SerializeField] private Image reloadBGImage;
        [SerializeField] private Image reloadImage;
        [SerializeField] private TextMeshProUGUI reloadText;

		[Header("Manacoast")]
        [SerializeField] private GameObject manacoastGO;
        [SerializeField] private Image notEnoughManaImage;
        [SerializeField] private TextMeshProUGUI manacoastText;

		[Header("Hotkey")]
        [SerializeField] private TextMeshProUGUI hotkeyText;

		public void UpdateGUI(float reloadTime, float toReload, bool enoughMana) {
			// Перезарядка
            reloadImage.fillAmount = (reloadTime <= 0) ? 0 : (toReload / reloadTime);

            reloadText.text = toReload.ToString("0");
            reloadText.gameObject.SetActive(toReload > 0);
			reloadBGImage.gameObject.SetActive(toReload > 0);

			// Если не хватает маны
			notEnoughManaImage.gameObject.SetActive(!enoughMana);
        }

        public void Setup(Sprite sprite, string hotKeyName, float manacoast) {
            hotkeyText.text = hotKeyName;
            icon.sprite = sprite;
			manacoastText.text = manacoast.ToString();
			manacoastGO.SetActive(manacoast > 0);
		}
    }
}
