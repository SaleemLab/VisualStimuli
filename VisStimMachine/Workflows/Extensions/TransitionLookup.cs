using Bonsai;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using StateMachineDefinition;

[Combinator]
[Description("")]
[WorkflowElementCategory(ElementCategory.Transform)]
public class TransitionLookup
{
    public DualState Key { get; set; }

    public IObservable<DualState> Process(IObservable<IDictionary<Tuple<string, string>, Tuple<string, string>>> source)
    {
        // return source.Select(value => value[new Tuple<string, string>(Key.VisualStateName, Key.LogicStateName)]);
        return source.Select(value =>
        {
            var transition = value[new Tuple<string, string>(Key.VisualStateName, Key.LogicStateName)];
            return new DualState
            {
                VisualStateName = transition.Item1,
                LogicStateName = transition.Item2
            };
        });
    }
}
