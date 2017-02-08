using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class RenderPositionSystem : ReactiveSystem {

    public RenderPositionSystem(Contexts contexts) : base(contexts.game) {
    }

    protected override Collector GetTrigger(Context context) {
        return context.CreateCollector(GameMatcher.Position);
    }

    protected override bool Filter(Entity entity) {
        return entity.hasView && entity.hasPosition;
    }

    protected override void Execute(List<Entity> entities) {
        foreach(var e in entities) {
            var pos = e.position;
            e.view.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
        }
    }
}