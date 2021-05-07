using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Super.Blazor.Toolbar.Services
{
    public interface IToolbarService
    {
        event Action<Type, RenderFragment>? Added;

        event Action<Type?>? Reset;

        IToolbarService Clear();

        IToolbarService Clear<TToolbar>()
            where TToolbar : Toolbar;

        public IToolbarService Set<TToolbar, TComponent>()
            where TToolbar : Toolbar
            where TComponent : IComponent
            => Set<TToolbar, TComponent>(new Dictionary<string, object>());

        public IToolbarService Set<TToolbar, TComponent>(ParameterView parameters)
            where TToolbar : Toolbar
            where TComponent : IComponent
            => Set<TToolbar, TComponent>(parameters.ToDictionary());

        IToolbarService Set<TToolbar, TComponent>(IReadOnlyDictionary<string, object> parameters)
            where TToolbar : Toolbar
            where TComponent : IComponent;
    }
}
