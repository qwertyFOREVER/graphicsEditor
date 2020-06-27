using System;
using System.Runtime.Serialization;

namespace VectorGraphicRedactor
{
    [DataContract]
    public class PulseAnimation : IAnimatable
    {
        [DataMember]
        private double intensity;
        [DataMember]
        private int time;
        [DataMember]
        private double rate;
        [DataMember]
        private readonly int delay;
        [DataMember]
        private readonly int coefficient;
        public double Intensity { get => intensity; set => intensity = value; }
        public PulseAnimation(double intensity)
        {
            delay = 3;
            Intensity = intensity / 20;
            coefficient = 1000;
        }

        public void Tick(Figure figure)
        {
            time = ++time % coefficient;
            rate = ++rate % coefficient;

            if (time % delay == 0)
            {
                figure.ScaleX += Math.Sin(rate) * intensity;
                figure.ScaleY += Math.Sin(rate) * intensity;
            }
        }
    }
}