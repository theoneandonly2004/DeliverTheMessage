namespace VRTK.Examples
{
    using UnityEngine;

    public class Sword : VRTK_InteractableObject
    {
        private float impactMagnifier = 120f;
        private float collisionForce = 0f;
        private float maxCollisionForce = 4000f;
        private VRTK_ControllerReference controllerReference;
        GameObject blood;
        bool can_damage = true;

        public float CollisionForce()
        {
            return collisionForce;
        }

        public override void Grabbed(VRTK_InteractGrab grabbingObject)
        {
            base.Grabbed(grabbingObject);
            controllerReference = VRTK_ControllerReference.GetControllerReference(grabbingObject.controllerEvents.gameObject);
        }

        public override void Ungrabbed(VRTK_InteractGrab previousGrabbingObject)
        {
            base.Ungrabbed(previousGrabbingObject);
            controllerReference = null;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            controllerReference = null;
            interactableRigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }

        private void OnCollisionEnter(Collision other)
        {
            Debug.Log("i hit something:" + other.gameObject.tag);

            if (VRTK_ControllerReference.IsValid(controllerReference) && IsGrabbed())
            {
                if(other.gameObject.tag == "enemy")
                {
                    if(can_damage)
                    {
                        blood = other.gameObject.GetComponent<Monster_Controller>().blood.gameObject;
                        blood.gameObject.transform.position = other.transform.position;
                        blood.gameObject.SetActive(true);
                        Invoke("disable_in_time", 1.0f);
                        other.gameObject.GetComponent<Monster_Controller>().current_health -= 50.0f;
                        can_damage = false;
                        Debug.Log("i did damage, you now have: " + other.gameObject.GetComponent<Monster_Controller>().current_health);
                    }  

                }
                Debug.Log("buzz buzz");
                VRTK_ControllerHaptics.TriggerHapticPulse(controllerReference, 10.0f, 0.5f, 0.01f);
            }
            else
            {
                if(!VRTK_ControllerReference.IsValid(controllerReference))
                {
                    Debug.Log("invalid controller");
                }
                
                if(!IsGrabbed())
                {
                    Debug.Log("not grabbed");
                }

            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.gameObject.tag == "enemy")
            {
                can_damage = true;
            }
        }


        void disable_in_time()
        {
            blood.gameObject.SetActive(false);
        }
    }
}