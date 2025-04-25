using Bonsai;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

public class MotionCoherenceParams
{
    public float? Duration { get; set; }
    public float? Size { get; set; } 
    public int? dotLifeBool { get; set; }
    public int? dotLifetime { get; set; }
    public float? Colour1 { get; set; }
    public float? Colour2 { get; set; }
    public float? numDots1 { get; set; }
    public float? numDots2 { get; set; }


    public float? Contrast1 { get; set; }
    public float? Contrast2 { get; set; }

    public float? VelocityX1 { get; set; }
    public float? VelocityX2 { get; set; }
    public float? VelocityY1 { get; set; }
    public float? VelocityY2 { get; set; }
    public float? Coherence1 { get; set; }
    public float? Coherence2 { get; set; }

}

[Combinator]
[Description("Creates a sequence of dot motion parameters used for stimulus presentation.")]
[WorkflowElementCategory(ElementCategory.Source)]
public class MotionCoherenceSpecification
{
    private List<MotionCoherenceParams> trials = new List<MotionCoherenceParams>();

    public List<MotionCoherenceParams> Trials
    {
        get { return trials;}
    }
    
    public IObservable<MotionCoherenceParams> Process()
    {
        return trials.ToObservable();
    }

    public IObservable<MotionCoherenceParams> Process<TSource>(IObservable<TSource> source)
    {
        return source.SelectMany(input => trials);
    }
}
