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
public class GenerateDotField
{
    public int numDots { get; set; }
    public float left { get; set; }
    public float right { get; set;}
    public float top { get; set; }
    public float bottom { get; set; }
    public int rndseed {get; set; }

    public IObservable<Vector2[]> Process()
    {
        var random = new Random(rndseed);
        var result = new Vector2[numDots];
        for (int i = 0; i < result.Length; i++)
        {
            result[i].X = (float)(random.NextDouble() * 2 - 1) * Math.Abs(right - left) /2f;
            result[i].Y = (float)(random.NextDouble() * 2 - 1) * Math.Abs(top - bottom) /2f - bottom;
            //Console.WriteLine(result[i].X);
            //Console.WriteLine(random.NextDouble() * 2 - 1);
        }
        return Observable.Return(result);
    }

   // public IObservable<Vector2[]> Process<TSource>(IObservable<TSource> source)
   // {
  //      var random = new Random(32);
  //      return source.Select(input =>
     //   {
  //          var result = new Vector2[numDots];
  //          for (int i = 0; i < result.Length; i++)
   //         {
   //             result[i].X = (float)(random.NextDouble() * 2 - 1) * Scale;
    //            result[i].Y = (float)(random.NextDouble() * 2 - 1) * Scale;
   //         }
        //    return result;
   //     });
 //   }
}
