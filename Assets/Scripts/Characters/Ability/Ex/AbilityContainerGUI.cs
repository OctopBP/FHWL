using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Abilities
{
    [ExecuteInEditMode]
    public class AbilityContainerGUI : MonoBehaviour
    {
		[Header("Отступ между способностями")]
		[Tooltip("Поцент от ширины экрана")]
        [SerializeField] private float space;

        private float scaledSpace;
        
        private List<AbilityGUI> abilitys;

		private RectTransform rectTransform;

        private void Start() {
			rectTransform = GetComponent<RectTransform>();

            abilitys = new List<AbilityGUI>();
			scaledSpace = rectTransform.rect.width * (space / 100);

            foreach (Transform child in transform) {
                AddAbility(child.GetComponent<AbilityGUI>());
            }
        }

        private void AddAbility(AbilityGUI ability) {
            abilitys.Add(ability);

            var childCount = transform.childCount;

            if (childCount == 0)
                return;

            var containerSize = rectTransform.rect.size;
            var cellWidth = ((containerSize.x - space * (childCount - 1)) / childCount);
            var cellSize = Mathf.Min(cellWidth, containerSize.y);

            var i = 0;
            foreach (Transform child in transform) {
                var childRect = child.GetComponent<RectTransform>();
                childRect.sizeDelta = new Vector2(cellSize, cellSize);
                childRect.anchoredPosition = new Vector2((cellSize + scaledSpace) * i, 0);
                
                i++;
            }
        }
    }
}
