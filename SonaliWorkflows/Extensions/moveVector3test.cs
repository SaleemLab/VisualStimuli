using Bonsai;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using OpenTK;

[Combinator]
[Description("")]
[WorkflowElementCategory(ElementCategory.Transform)]
public class moveVector3test
{

        public float VelocityX  {get; set; }
        public float VelocityY  {get; set; }

        public float VelocityZ  {get; set; }

        public int Coherence { get ; set; }
        public float top { get; set; }
        public float bottom { get; set; }
        public float left { get; set; }
        public float right { get; set; }
        public float front { get; set; }
        public float back { get; set; }
        public float frameRate { get; set; }
    public IObservable<Vector3[]> Process(IObservable<Vector3[]> source)
    {
        return source.Select(value => 
        {
            Vector3 Velocity = new Vector3(VelocityX,VelocityY,VelocityZ);
            Random rng = new Random(25); // same seed every frame
            int nDots = value.Length;
            float nDotsf = value.Length;   
            float nCohf = nDotsf/100f * Coherence;
            int nCoh = (int)Math.Ceiling(nCohf);
            if (nCoh>nDots)
            {
                nCoh=nDots;
            };
            //int nCoh = nDots/100 * Coherence;
            var result = value;
            float velmag = Velocity.Length;

        // Coherent dots
            for (int i = 0; i < nCoh; i++)
        {
            result[i] = result[i] + Velocity; // just add the coherent velocity vector
        }

        // Incoherent Dots
          for (int i = nCoh; i < nDots; i++)
        { 
            // new random vector for each incoherent dot
            float x = (float)rng.Next(0,100)-50f;
            float y = 0f;//(float)rng.Next(0,100)-50f;
            float z = (float)rng.Next(0,100)-50f;
            Vector3 TempVel = new Vector3 (x,y,z);
            Vector3 TempVel2 = TempVel/TempVel.Length;
            Vector3 TempVel3 = TempVel2 * velmag;
            result[i] = result[i] + TempVel3;
        }


            wrapAround(result, nDots, top, bottom, left, right, front, back);



            return result;
            
        });
        }

    private void wrapAround(Vector3[] dotPos, int nDots, float top, float bottom, float left, float right, float front, float back)
    {
        float horizontal = Math.Abs(right - left);
        float vertical = Math.Abs(top - bottom);
        float depth = Math.Abs(front - back);

        for (int i = 0; i < nDots; i++)
        {

            if (dotPos[i].X > right) { dotPos[i].X = dotPos[i].X - horizontal; }
            else if (dotPos[i].X < left) { dotPos[i].X = dotPos[i].X + horizontal; }

            if (dotPos[i].Y > top) { dotPos[i].Y = dotPos[i].Y - vertical; }
            else if (dotPos[i].Y < bottom) { dotPos[i].Y = dotPos[i].Y + vertical; }

            if (dotPos[i].Z > front) { dotPos[i].Z = dotPos[i].Z - depth; }
            else if (dotPos[i].Z < back) { dotPos[i].Z = dotPos[i].Z + depth; }

        }
    }
}
