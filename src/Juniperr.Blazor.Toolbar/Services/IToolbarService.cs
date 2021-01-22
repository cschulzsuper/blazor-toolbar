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

        public IToolbarService Set<TToolbarComponent>(int position)
            where TToolbarComponent : ToolbarComponentBase
            => Set<TToolbarComponent>(0, position);

        public IToolbarService Set<TToolbarComponent>(int position, ParameterView parameters)
            where TToolbarComponent : ToolbarComponentBase
            => Set<TToolbarComponent>(0, position, parameters);

        public IToolbarService Set<TToolbarComponent>(int position, IReadOnlyDictionary<string, object> parameters)
            where TToolbarComponent : ToolbarComponentBase
            => Set<TToolbarComponent>(0, position, parameters);

        public IToolbarService Set<TToolbarComponent>(int group, int position)
            where TToolbarComponent : ToolbarComponentBase
            => Set<TToolbarComponent>(group, position, new Dictionary<string, object>());

        public IToolbarService Set<TToolbarComponent>(int group, int position, ParameterView parameters)
            where TToolbarComponent : ToolbarComponentBase
            => Set<TToolbarComponent>(group, position, parameters.ToDictionary());

        IToolbarService Set<TToolbarComponent>(int group, int position, IReadOnlyDictionary<string, object> parameters)
            where TToolbarComponent : ToolbarComponentBase;
    }
}
