using System;
using System.Runtime.Serialization;

namespace VectorGraphicRedactor
{
    [DataContract]
    public class TranslateAnimation : IAnimatable
    {
        [DataMember]
        private double speed;
        [DataMember]
        private double ticks;
        
        public double Speed { get => speed; set => speed = value; }
        
        public TranslateAnimation(double speed)
        {
            Speed = speed;
        }
        
        public void Tick(Figure figure)
        {
            ticks = ++ticks % 360;
            
            figure.OffsetX = Math.Sin(ticks / Math.PI) * speed;
            figure.OffsetY = Math.Cos(ticks / Math.PI) * speed;
        }
    }
}