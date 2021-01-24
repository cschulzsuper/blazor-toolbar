using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Juniperr.Blazor.Toolbar.Services
{
    public interface IToolbarService
    {
        public event Action<Type, int, RenderFragment>? Added;

        public event Action<Type?>? Reset;

        public IToolbarService Clear();

        public IToolbarService Clear<TToolbar>()
            where TToolbar : Toolbar;

        public IToolbarService Set<TToolbar, TComponent>(int position)
            where TToolbar : Toolbar
            where TComponent : IComponent
            => Set<TToolbar, TComponent>(position, new Dictionary<string, object>());

        public IToolbarService Set<TToolbar, TComponent>(int position, ParameterView parameters)
            where TToolbar : Toolbar
            where TComponent : IComponent
            => Set<TToolbar, TComponent>(position, parameters.ToDictionary());

        IToolbarService Set<TToolbar, TComponent>(int position, IReadOnlyDictionary<string, object> parameters)
            where TToolbar : Toolbar
            where TComponent : IComponent;
    }
}
