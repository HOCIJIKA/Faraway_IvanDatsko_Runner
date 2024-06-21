using MoveParametersModifiers;
using UnityEngine;

namespace Ivan.MoveModifiers
{
    /// <summary>
    /// Player movement modifier Fly
    /// </summary>
    public class Fly : BaseMove
    {
        private const float FlightHeight = 2;

        public Fly() : base(new BaseParameters(1f)) { }

        public override void Move(PlayerController playerController)
        {
            base.Move(playerController);
            playerController.PlayerMovement.PlayerRigidbody.isKinematic = true;
            playerController.transform.position = MoveToFlyPosition(playerController.transform, FlightHeight);
        }

        /// <summary>
        /// Flight of the player at a height
        /// </summary>
        /// <param name="transform"> player transform</param>
        /// <param name="height">Flight height</param>
        /// <returns></returns>
        private Vector2 MoveToFlyPosition(Transform transform, float height)
        {
            return new Vector2(transform.position.x, height);
        }
    }
}
