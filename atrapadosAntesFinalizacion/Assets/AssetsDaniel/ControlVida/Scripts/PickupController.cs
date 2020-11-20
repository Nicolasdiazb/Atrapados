using UnityEngine;

namespace SurvivalUISystem
{
    public class PickupController : MonoBehaviour
    {
        [SerializeField] private int itemValue;
        [SerializeField] private PickupType myPickups;
        [SerializeField] private SurvivalUIController uiController;

        public enum PickupType { None, DamageObject, HealObject, HungerObject, ThirstObject, StaminaObject }

        void Start()
        {
            Debug.Log("lame a este desde lejos far qawau");
           
        }
           
        

        private void OnTriggerEnter(Collider other)
        {
            
            if (other.CompareTag("xrrig"))
            {
                Debug.Log("toqué al jugador");
                if (myPickups == PickupType.HealObject)
                {
                    Debug.Log("cojí vida");

                    uiController.UpdateHealth("Heal", itemValue);
                }

                if (myPickups == PickupType.DamageObject)
                {
                    Debug.Log("cojí daño");
                    uiController.UpdateHealth("Damage", itemValue);
                }


                if (myPickups == PickupType.HungerObject)
                {
                    uiController.UpdateVitals("Hunger", itemValue);
                }

                if (myPickups == PickupType.ThirstObject)
                {
                    uiController.UpdateVitals("Thirst", itemValue);
                }

                if (myPickups == PickupType.StaminaObject)
                {
                    uiController.UpdateStamina("StaminaItem", itemValue);
                }

                this.gameObject.SetActive(false);
            }
        }
    }
}
