using Bonsai;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

public class SphereFieldParameters
{
    public float? Duration { get; set; }
    public float? Size { get; set; }
    public float? Colour1 { get; set; }
    public float? Colour2 { get; set; }
    public float? numDots1 { get; set; }
    public float? numDots2 { get; set; }
    public int? dotLifeBool { get; set; }
    public int? dotLifetime { get; set; }
    public float? Contrast { get; set; }
    public float? VelX { get; set; }
    public float? VelY { get; set; }
    public float? VelZ { get; set; }
    public float? Coherence { get; set; }

}

[Combinator]
[Description("Creates a sequence of dot motion parameters used for stimulus presentation.")]
[WorkflowElementCategory(ElementCategory.Source)]
public class SphereFieldSpecification
{
    private List<SphereFieldParameters> trials = new List<SphereFieldParameters>();

    public List<SphereFieldParameters> Trials
    {
        get { return trials;}
    }
    
    public IObservable<SphereFieldParameters> Process()
    {
        return trials.ToObservable();
    }

    public IObservable<SphereFieldParameters> Process<TSource>(IObservable<TSource> source)
    {
        return source.SelectMany(input => trials);
    }
}
