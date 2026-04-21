---
name: Đánh giá SpaceGo vs GDD
overview: Dự án code đã có prototype gameplay đúng tinh thần [space_go_mvp_gdd_1_month.md](e:/Game/SpaceGo-ProjectGame/space_go_mvp_gdd_1_month.md); cần bổ sung systems/UI/save và chỉnh tài liệu để tránh xung đột với tầm nhìn 6 tháng trong [SpaceGo Project.md](e:/Game/SpaceGo-ProjectGame/SpaceGo%20Project.md).
todos:
  - id: doc-phase
    content: Ghi rõ Phase 1 = MVP GDD 1 tháng; Hardcore = sau MVP (tránh scope creep)
    status: pending
  - id: save-economy
    content: SaveManager + persist best score/total coins; công coin khi Game Over
    status: pending
  - id: coin-obstacles
    content: Spawner coin collectible + 2-3 kiểu obstacle/prefab theo GDD
    status: pending
  - id: scenes-ui
    content: MainMenu + Gameplay scenes; Canvas HUD/GameOver/Shop/Pause thay OnGUI
    status: pending
  - id: skins-themes
    content: 3 skin tàu + 2 theme unlock/equip + shop đơn giản
    status: pending
  - id: mobile-polish
    content: Android build test; object pool; cân bằng độ khó; BGM + SFX asset
    status: pending
isProject: false
---

# Đánh giá hướng dự án SpaceGo và việc cần làm

## Hai tài liệu: không mâu thuẫn nếu phân tầng rõ

- **[SpaceGo Project.md](e:/Game/SpaceGo-ProjectGame/SpaceGo%20Project.md)** mô tả **“Hardcore Edition”** đầy đủ: Boss theo mốc điểm, shop/IAP/ads, leaderboard, grind skin đắt, roadmap ~6 tháng.
- **[space_go_mvp_gdd_1_month.md](e:/Game/SpaceGo-ProjectGame/space_go_mvp_gdd_1_month.md)** là **MVP 4 tuần**: cố ý **không** làm Boss, IAP, leaderboard; economy nhẹ hơn (skin 50/120/250 coin); 2 scene (Menu + Gameplay); polish mobile.

**Kết luận định hướng:** Nên coi **MVP GDD là “Phase 1 – triển khai ngay”** và **SpaceGo Project.md là “Phase 2+”** sau khi MVP ổn. Nếu cố làm theo file Hardcore trong 1 tháng thì scope sẽ vỡ; repo hiện tại thực tế đang gần MVP hơn là bản Hardcore đầy đủ.

---

## So sánh nhanh: code hiện tại vs MVP GDD

| Hướng MVP GDD | Tình trạng trong repo |
|----------------|------------------------|
| Điều khiển chạm trên/dưới tàu + lực impulse | **Có** – [`PlayerShipController.cs`](e:/Game/SpaceGo-ProjectGame/Assets/Scripts/PlayerShipController.cs) (`worldPoint.y > transform.position.y` → lực xuống, ngược lại lên) |
| Bắn mỗi lần chạm (input) | **Gần đủ** – có `shootCooldown` nên không phải mỗi frame; với touch `Began` thì gần như mỗi lần chạm một viên (chấp nhận được cho mobile) |
| Scroll obstacle/enemy, tốc độ theo điểm | **Có** – [`ScrollMover.cs`](e:/Game/SpaceGo-ProjectGame/Assets/Scripts/ScrollMover.cs) + [`SpaceGoGameManager.cs`](e:/Game/SpaceGo-ProjectGame/Assets/Scripts/SpaceGoGameManager.cs) (`ScrollSpeed`, `DifficultyLevel`) |
| Score + Game Over + Retry | **Có** – điểm tăng theo thời gian; `OnGUI` cho HUD và nút Play Again |
| Enemy đơn giản (tùy chọn) | **Có** – [`EnemyShip.cs`](e:/Game/SpaceGo-ProjectGame/Assets/Scripts/EnemyShip.cs), spawn trong [`ObstacleSpawner.cs`](e:/Game/SpaceGo-ProjectGame/Assets/Scripts/ObstacleSpawner.cs) |
| Đạn phá obstacle / enemy | **Có** – [`Projectile.cs`](e:/Game/SpaceGo-ProjectGame/Assets/Scripts/Projectile.cs) |
| **Coin trên đường bay** (rủi ro/phần thưởng) | **Chưa** – coin chỉ đến từ phá obstacle/enemy (`AddCoins`), không có collectible spawn như mục 8.4 GDD |
| **2–3 loại obstacle** (sprite/hành vi khác nhau) | **Chưa đủ** – chỉ asteroid với scale ngẫu nhiên, chưa tách prefab/type như GDD |
| **Lưu local** (best score, tổng coin, unlock skin/theme) | **Chưa** – không `PlayerPrefs`/JSON; mỗi run reset coin trong manager |
| **Main Menu**, Play/Shop/Settings | **Chưa** – [`GameBootstrap.cs`](e:/Game/SpaceGo-ProjectGame/Assets/Scripts/GameBootstrap.cs) spawn mọi thứ trong một scene ([`SampleScene.unity`](e:/Game/SpaceGo-ProjectGame/Assets/Scenes/SampleScene.unity)) |
| **UI Canvas** (HUD, Pause, Game Over panel) | **Chưa** – đang dùng `OnGUI` (khó polish, không đạt checklist UI mobile trong GDD) |
| **Pause** | **Chưa** |
| **3 skin tàu + 2 theme**, shop buy/equip | **Chưa** – visual mặc định qua `SpaceGoContentLibrary`; parallax cố định trong bootstrap |
| **BGM + SFX** | **Một phần** – [`GameAudio.cs`](e:/Game/SpaceGo-ProjectGame/Assets/Scripts/GameAudio.cs) chỉ SFX procedural; GDD yêu cầu BGM loop |
| **Object Pooling** (tuần 4 GDD) | **Chưa** – Instantiate/Destroy cho đạn và obstacle |
| **Cấu trúc `Assets/_Game/...`** | **Chưa** – script nằm phẳng `Assets/Scripts/` |
| GDD gợi ý **Input System** mới | **Chưa** – dùng `Input.touches` / mouse |

```mermaid
flowchart LR
  subgraph done [Da_co]
    Core[Core_move_shoot_scroll]
    Diff[Difficulty_scaling]
    Enemy[Enemy_optional]
  end
  subgraph gap [Can_ba_sung_MVP]
    Save[SaveManager]
    Menu[MainMenu_scene]
    UI[Canvas_UI_pause]
    CoinSpawn[Coin_collectibles]
    Content[Multi_obstacle_skin_theme]
    Pool[Object_pool]
    Build[Android_build_polish]
  end
  Core --> Save
  Core --> Menu
  Menu gameplay[Gameplay_scene] --> UI
```

---

## Việc nên làm để “triển khai lần một” đúng MVP (theo lộ trình 4 tuần GDD)

1. **Cố định single source of truth**  
   Ghi rõ trong đầu dự án (hoặc một dòng trong README khi bạn sẵn sàng): Phase 1 = file MVP 1 tháng; Boss/IAP/leaderboard = sau MVP.

2. **Tuần 1–2 (nền tảng loop)**  
   - Thêm **`SaveManager`** (PlayerPrefs đủ cho MVP): best score, total coins, equipped skin/theme, unlock flags.  
   - **Cộng coin vào tổng khi Game Over**; hiển thị “coin kiếm được / tổng” trên panel.  
   - **Spawner coin** (object có trigger + ScrollMover + reward) theo pattern đơn giản.  
   - Tách thêm **1–2 prefab obstacle** (vd. “lớn không bắn vỡ” / “nhỏ bắn vỡ”) nếu GDD yêu cầu phân biệt hành vi — ít nhất phân biệt **destructible vs static** bằng flag/script.

3. **Tuần 3 (sản phẩm nhỏ hoàn chỉnh)**  
   - Scene **`MainMenu`** + **`Gameplay`**, chuyển scene từ nút Play.  
   - Thay **`OnGUI`** bằng **Canvas + TextMeshPro** (HUD, Game Over, Shop popup).  
   - **Pause** (timeScale hoặc flag trong manager) + panel Resume / Restart / Menu.  
   - **Shop**: 3 skin + 2 theme (ScriptableObject hoặc data class đơn giản), nút Buy/Equip, đọc/ghi save.  
   - **Bây giờ** mới gắn asset thật vào `SpaceGoContentLibrary` hoặc thay player/build bằng prefab — tránh over-engineer trước khi có UI/state lưu.

4. **Tuần 4 (mobile)**  
   - Build **Android**, chỉnh **aspect ratio** (đã có `MobileViewport` / `MobileCameraScaler` — tiếp tục test thiết bị thật).  
   - **Object pool** cho bullet + obstacle/coin nếu thấy GC spike (đúng hướng GDD).  
   - Cân bằng `speedIncreaseEveryPoints`, spawn interval, `enemyChance` theo target 10–20s / 40–60s trong GDD §19.  
   - Rewarded/Interstitial chỉ khi còn thời gian (optional trong MVP).

5. **Tinh chỉnh nhỏ cho đúng “feel” GDD**  
   - GDD §19 gợi ý **impulse lên/xuống khác nhân** — hiện chỉ một `impulsePower`; có thể tách `upImpulse` / `downImpulse` và **clamp velocity** (`maxRiseSpeed` / `maxFallSpeed`).  
   - Cân nhắc **Input System package** nếu muốn khớp §14.1 (không bắt buộc nếu legacy input đã ổn trên Android).

---

## Trả lời trực tiếp câu hỏi của bạn

- **“Đã đi đúng hướng chưa?”** — **Đúng hướng cho MVP**: phần risky nhất (feel điều khiển + một tay làm nhiều việc) đã được code; phần “làm thành game phát hành” (save, menu, shop, UI đẹp, content) vẫn **chưa**.  
- **“Cần thay đổi làm gì?”** — Ưu tiên **save + hai scene + UI Canvas + coin trên map + unlock skin/theme + obstacle đa dạng + pool + build** như trên; đồng thời **không** ôm Boss/IAP/leaderboard của file Hardcore trong vòng MVP 1 tháng.
