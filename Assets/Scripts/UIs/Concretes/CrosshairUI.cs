using UnityEngine;
using UnityEngine.UI;

namespace ANKU.UIs.Concretes
{
    public class CrosshairUI : MonoBehaviour
    {
        private void Update()
        {
            SetCrosshairColor();
        }

        private void SetCrosshairColor()
        {
            this.gameObject.GetComponent<Image>().color = Color.white;
        }
    }
}