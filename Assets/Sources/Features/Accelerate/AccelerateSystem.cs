using System.Collections.Generic;
using Entitas;

public class AccelerateSystem : IReactiveSystem, ISetPool {
    public IMatcher trigger { get { return CoreMatcher.Accelerating; } }

    public GroupEventType eventType { get { return GroupEventType.OnEntityAddedOrRemoved; } }

    Group _group;

    public void SetPool(Pool pool) {
        _group = pool.GetGroup(Matcher.AllOf(CoreMatcher.Acceleratable, CoreMatcher.Move));
    }

    public void Execute(List<Entity> entities) {
        var accelerate = entities.SingleEntity().isAccelerating;
        foreach (var e in _group.GetEntities()) {
            var move = e.move;
            var speed = accelerate ? move.maxSpeed : 0;
            e.ReplaceMove(speed, move.maxSpeed);
        }
    }
}

