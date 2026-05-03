# Unity Roguelike Portfolio

2D top-down roguelike built in Unity 6 focused on clean architecture and gameplay systems.

🎮 [Play in browser on itch.io](https://alexandermla.itch.io/roguelike-portfolio)

> ⚠️ Prototype with placeholder art — focus is on code architecture, not visuals.

---

## Gameplay

Survive as long as possible while eliminating enemies that appear in progressive waves.

**Controls:** WASD — Move | Mouse — Aim | Left Click — Attack

---

## Systems Implemented

| System | Key Features |
|--------|-------------|
| Player | Input System, directional melee attack, sweep hitbox |
| Health | ScriptableObject-based, reusable for player and enemies |
| Combat | Melee arc attack, knockback, hit flash feedback |
| Enemy AI | Follow target, contact damage, death handler |
| Wave | Progressive difficulty, more enemies + speed + health per wave |
| Score | Fully event-driven, no direct references |
| Game Over | Scene restart, timescale pause, UI panel |
| UI | TextMeshPro, all updated via events, no hardcoded text |

---

## Architecture

- ✅ Decoupled communication via C# events and UnityEvents
- ✅ ScriptableObjects for all configurable data (stats, waves, attacks)
- ✅ Single responsibility per script
- ✅ No direct dependencies between systems
- ❌ No singletons, no hardcoded values, no logic in UI scripts

---

## Built With

- Unity 6 (6000.3.14f1)
- C#
- Unity Input System
- TextMeshPro
