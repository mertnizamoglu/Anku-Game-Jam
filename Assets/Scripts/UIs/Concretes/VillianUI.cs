using System;
using ANKU.Controllers.Concretes;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ANKU.UIs.Concretes
{
    public class VillianUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private GunController gun;

        private void Start()
        {
            
        }

        private void Update()
        {
            SetAmmoText();
        }

        private void SetAmmoText()
        {
            text.text = gun.CurrentAmmoCount.ToString();
        }
    }
}