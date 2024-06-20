using UnityEngine;

namespace Ivan.MoveModifiers
{
    public class Fly : BaseMove
    {
        public Fly() : base(new BaseParameters(1f)) { }

        public override void Move(PlayerController playerController)
        {
            base.Move(playerController);
            playerController.PlayerMovement.PlayerRigidbody.isKinematic = true;
            playerController.transform.position = MoveToPositionY(playerController.transform);
        }

        private Vector2 MoveToPositionY(Transform transform)
        {
            return new Vector2(transform.position.x, 2);
        }
    }
}
