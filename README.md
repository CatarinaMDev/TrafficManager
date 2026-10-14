# 🚦 Traffic Manager (2026)

> A fast-paced 2D top-down traffic management simulation developed in Unity.

A severe storm has knocked out the city's automated traffic light grid, and repair crews cannot fix it in time. It is up to you to take manual control of the intersections, manage the madness, and ensure that traffic flows smoothly without catastrophic collisions.

## 📖 Concept & Objective
The player acts as the manual override for a dangerous intersection. You must manage traffic lights to safely let a specific number of vehicles pass while handling the chaos of slow-moving trucks, high-speed trains, and impatient emergency responders.

*   **Win Condition:** Safely guide the required quota of vehicles through the intersection.
*   **Lose Conditions:**
    *   *Collision:* Any vehicle crashing into another car or train.
    *   *Traffic Backup:* The waiting queue extends beyond the off-screen limits.
    *   *Ignored Emergencies:* Emergency vehicles will force their way through a red light if their patience runs out, almost guaranteeing a crash.

## 🎮 Core Mechanics & Entities

**Basic Controls:** Fully mouse-driven (PC) or touch-driven (Mobile). Click/Tap a traffic light to seamlessly toggle it between Green (Go) and Red (Stop).

### Vehicle Ecosystem
Each vehicle pulls from a predefined color palette and features unique behaviors:

| Vehicle Type | Speed | Special Behavior / Threat |
| :--- | :--- | :--- |
| **Cars** | Medium | Standard traffic unit. |
| **Trucks** | Slow | Takes longer to clear the intersection, causing backups. |
| **Emergency (Police/Ambulance)** | Fast | **Patience Mechanic:** Starts honking if clicks drop below 4. Runs red lights if patience hits zero. |
| **Trains** | Medium | Unstoppable vehicles. Triggers a warning 4 seconds before arrival. |
| **Boats** | Slow | Background entities moving dynamically along the river. |

---

## ⚙️ Technical Architecture (Under the Hood)

This project was built to test and demonstrate system management, algorithmic spawn prevention, and robust UI/Audio architecture.

### 🧮 Mathematics & Scaling
*   **Dynamic Level Scaling:** `Total Cars Needed = (Level * Level) * 2 + 8`
*   **Spawn Probabilities:** Cars (50%) | Trucks (30%) | Police (10%) | Ambulance (10%)

### 🚗 Dynamic Spawn Allocation (Collision Prevention)
To prevent physics glitches and unfair Game Over states caused by vehicles spawning on top of each other, the game uses a dynamic List reduction algorithm uniformly across all entities (Road Vehicles, Trains, Boats):
1. During a spawn cycle, all available spawn points are copied into a temporary `List<GameObject>`.
2. When an entity is spawned, its location is removed from the list (`RemoveAt`).
3. Any subsequent vehicles generated in the same frame are forced to pick from the remaining unoccupied
