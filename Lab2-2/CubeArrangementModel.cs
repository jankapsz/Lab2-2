using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szeminarium
{
    internal class CubeArrangementModel
    {
        /// <summary>
        /// Gets or sets wheather the animation should run or it should be frozen.
        /// </summary>
        public bool AnimationEnabled { get; set; } = false;

        /// <summary>
        /// The time of the simulation. It helps to calculate time dependent values.
        /// </summary>
        private double Time { get; set; } = 0;


        public float rotationX { get; set; } = 0;
        public float rotationXDirection { get; set; } = 0;

        private float stopper = 0;
        private double stopperTime = 0;

        internal void AdvanceTime(double deltaTime)
        {
            // we do not advance the simulation when animation is stopped
            if (!AnimationEnabled)
                return;

            // set a simulation time
            Time += deltaTime;
            stopperTime += deltaTime;

            rotationX = (float)(Time * Math.PI / 2f) * rotationXDirection;
            stopper = (float)(stopperTime * Math.PI / 2f);

            if (stopper > Math.PI / 2f) // ha > 90 fok
            {
                AnimationEnabled = false;
                stopper = 0;
                stopperTime = 0;
            }
        }
    }
}
