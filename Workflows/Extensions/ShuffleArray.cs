using Bonsai;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

[Combinator]
[Description("")]
[WorkflowElementCategory(ElementCategory.Transform)]
public class ShuffleArray
{
    Random rnd = new Random();

    public IObservable<IList<TSource>> Process<TSource>(IObservable<IList<TSource>> source)
    {
        return source.Select(value =>
        {
            return value.OrderBy(x => rnd.Next()).ToList();
        });
    }
}
