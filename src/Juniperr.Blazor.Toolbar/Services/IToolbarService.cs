using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Juniperr.Blazor.Toolbar.Services
{
    public interface IToolbarService
    {
        event Action<int, int, RenderFragment>? Added;

        event Action<int?>? Reset;

        public IToolbarService Clear();

        public IToolbarService Clear(int group);

        public IToolbarService Set<TComponent>(int position)
            where TComponent : IComponent
            => Set<TComponent>(0, position);

        public IToolbarService Set<TComponent>(int position, ParameterView parameters)
            where TComponent : IComponent
            => Set<TComponent>(0, position, parameters);

        public IToolbarService Set<TComponent>(int position, IReadOnlyDictionary<string, object> parameters)
            where TComponent : IComponent
            => Set<TComponent>(0, position, parameters);

        public IToolbarService Set<TComponent>(int group, int position)
            where TComponent : IComponent
            => Set<TComponent>(group, position, new Dictionary<string, object>());

        public IToolbarService Set<TComponent>(int group, int position, ParameterView parameters)
            where TComponent : IComponent
            => Set<TComponent>(group, position, parameters.ToDictionary());

        IToolbarService Set<TComponent>(int group, int position, IReadOnlyDictionary<string, object> parameters)
            where TComponent : IComponent;
    }
}
