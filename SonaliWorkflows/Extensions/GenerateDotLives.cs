using Bonsai;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

[Combinator]
[Description("")]
[WorkflowElementCategory(ElementCategory.Source)]
public class GenerateDotLives
{
    public int dotLifetime { get; set; }
    public int numDots { get; set; }
    public IObservable<int[]> Process()
    {
        Random random = new Random((int)DateTime.Now.Ticks);
        int[] life = new int[numDots]; 
        for(int i = 0; i < numDots; i++ )
        {
             life[i] = (random.Next(0, dotLifetime));
        }
        return Observable.Return(life);
    }
}
