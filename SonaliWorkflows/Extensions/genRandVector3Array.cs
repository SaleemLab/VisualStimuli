using Bonsai;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using OpenTK;

[Combinator]
[Description("")]
[WorkflowElementCategory(ElementCategory.Source)]
public class genRandVector3Array
{
    public int numDots {get; set; }
    public float left { get; set; }
    public float right { get; set;}
    public float top { get; set; }
    public float bottom { get; set; }
    public float front { get; set; }
    public float back { get; set; }
    public int rngSeed { get; set; }

    public IObservable<Vector3[]> Process()
    {
        var random = new Random(rngSeed);
        var result = new Vector3[numDots];

        for (int i = 0; i < numDots; i++)
        {
            result[i].X = (float)(random.NextDouble() * 2 - 1) * Math.Abs(right - left) /2f;
            result[i].Y = (float)(random.NextDouble() * 2 - 1)* Math.Abs(top - bottom) /2f;
            result[i].Z = (float)(random.NextDouble() * 2 - 1)* Math.Abs(front - back) /2f;;
        }


        return Observable.Return(result);
    }
}
