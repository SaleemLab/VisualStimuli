using Bonsai;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

public class DoubleGratingParams
{
    public float? angle_g1 { get; set; }
    public float? angle_g2 { get; set; } 
    public float? contrast_g1 { get; set; }
    public float? contrast_g2 { get; set; }
    public float? opacity_g1 { get; set; }
    public float? opacity_g2 { get; set; }
    public float? phase_g1 { get; set; }
    public float? phase_g2 { get; set; }

    public float? temporalFrequency { get; set; }
    public float? spatialFrequency { get; set; }


}

[Combinator]
[Description("Creates a sequence of dot motion parameters used for stimulus presentation.")]
[WorkflowElementCategory(ElementCategory.Source)]
public class DoubleGratingSpecification
{
    private List<DoubleGratingParams> trials = new List<DoubleGratingParams>();

    public List<DoubleGratingParams> Trials
    {
        get { return trials;}
    }
    
    public IObservable<DoubleGratingParams> Process()
    {
        return trials.ToObservable();
    }

    public IObservable<DoubleGratingParams> Process<TSource>(IObservable<TSource> source)
    {
        return source.SelectMany(input => trials);
    }
}
