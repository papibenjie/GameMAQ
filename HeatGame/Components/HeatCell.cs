using System.Collections.Generic;
using GameMAQ.Lib;
using GameMAQ.Lib.Components.Sprites;
using Microsoft.Xna.Framework;

namespace HeatGame.Components
{
    internal class HeatCell : RectangleSprite
    {
        private List<Color> _colorGradient = new List<Color>();
        public double Temperature { get; set; } = 0;

        public double MinimumHeat { get; set; } = 0;
        public double MaximumHeat { get; set; } = 1000;
        public List<Color> ColorGradient { get; set; }
        public int ColorSteps { get; set; }

        public HeatCell(Vector2 size, double temperature, double minimumHeat, double maximumHeat, int colorSteps = 100) : base(size, Color.Black, Color.Green, 0)
        {
            Temperature = temperature;
            MinimumHeat = minimumHeat;
            MaximumHeat = maximumHeat;

            ColorGradient = GetHeatColorGradient(colorSteps);
            ColorSteps = colorSteps;
        }

        public List<Color> GetHeatColorGradient(int steps, Color? start = null, Color? end = null)
        {
            start ??= Color.Blue;
            end ??= Color.Red;
            List<Color> gradient = new List<Color>();
            int stepA = ((end.Value.A - start.Value.A) / (steps - 1));
            int stepR = ((end.Value.R - start.Value.R) / (steps - 1));
            int stepG = ((end.Value.G - start.Value.G) / (steps - 1));
            int stepB = ((end.Value.B - start.Value.B) / (steps - 1));

            for (int i = 0; i < steps; i++)
            {
                var col = new Color(start.Value.R + (stepR * i), start.Value.G + (stepG * i), start.Value.B + (stepB * i), start.Value.A + (stepA * i));
                gradient.Add(col);
            }
            return gradient;
        }

        /*public Color GetHeatColor()
        {
        }*/

        public override void Update()
        {
            base.Update();
        }

        public override void Initialize(GameObject gobj)
        {
            base.Initialize(gobj);
        }

        public override void Start()
        {
            base.Start();
        }
    }
}