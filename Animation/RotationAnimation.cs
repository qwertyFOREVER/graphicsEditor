using System.Runtime.Serialization;

namespace VectorGraphicRedactor
{
    [DataContract]
    public class RotationAnimation : IAnimatable
    {
        [DataMember]
        private double speed;
        public double Speed { get => speed; set => speed = value; }

        public RotationAnimation(double speed)
        {
            Speed = speed;
        }

        public void Tick(Figure figure)
        {
            figure.Angle = (figure.Angle + speed) % 360;
        }
    }
}