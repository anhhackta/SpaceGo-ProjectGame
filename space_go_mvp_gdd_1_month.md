# GDD – SpaceGo Mobile MVP (Kế hoạch hoàn thành trong 1 tháng)

## 1. Tổng quan dự án

**Tên game:** SpaceGo  
**Thể loại:** Arcade 2D – Endless Scroller  
**Nền tảng:** Mobile (ưu tiên Android, có thể mở rộng iOS)  
**Engine:** Unity 2D  
**Mục tiêu bản này:** Hoàn thành một bản game nhẹ, chơi được, có thể build mobile trong vòng **4 tuần**.  
**Định hướng:** Lấy cảm hứng từ Flappy Bird nhưng có điểm khác biệt ở cơ chế điều khiển và bắn đạn.

---

## 2. Tầm nhìn sản phẩm

SpaceGo là một game mobile 2D đơn giản, dễ hiểu, dễ vào chơi, nhưng có độ thử thách đủ để gây nghiện. Người chơi điều khiển một con tàu bay liên tục về phía trước trong không gian, vừa né chướng ngại vừa bắn đạn mỗi lần chạm.

Bản MVP tập trung vào:
- cảm giác điều khiển tốt,
- gameplay mượt,
- vòng chơi ngắn nhưng gây muốn chơi lại,
- có hệ coin và skin đủ để tạo động lực.

Bản MVP **không cố gắng trở thành dự án lớn** ngay từ đầu. Tất cả tính năng đều được chọn theo tiêu chí:
1. cần cho gameplay chính,
2. làm kịp trong 1 tháng,
3. dễ mở rộng về sau.

---

## 3. Mục tiêu của bản MVP

### 3.1 Mục tiêu chính
- Hoàn thành game mobile 2D nhẹ trong dưới 1 tháng.
- Tạo được gameplay “1 chạm nhưng khó dần”, dễ học và có replay value.
- Có 1 vòng lặp đủ hoàn chỉnh: **Menu → Chơi → Game Over → Chơi lại / Mua skin**.

### 3.2 Mục tiêu sản phẩm
- 1 bản build Android chơi được ổn định.
- Chạy tốt trên máy tầm trung.
- Dễ mở rộng thêm boss, ads, IAP, leaderboard ở giai đoạn sau.

### 3.3 Không nằm trong mục tiêu bản này
- Boss nhiều phase.
- IAP hoàn chỉnh.
- Leaderboard online.
- Nhiều map phức tạp.
- Nhiều loại enemy hoặc progression sâu.

---

## 4. Core gameplay

## 4.1 Ý tưởng cốt lõi
Người chơi điều khiển một tàu không gian bay liên tục từ trái sang phải theo cảm giác side scrolling. Màn hình sẽ trôi qua bên trái tạo cảm giác tàu tiến về phía trước.

Người chơi **không điều khiển hướng ngang**, chỉ điều khiển **độ cao của tàu** bằng thao tác chạm.

### Cơ chế điều khiển khác biệt
- Chạm **phía trên tàu** → đẩy tàu **xuống**.
- Chạm **phía dưới tàu** → kéo tàu **lên**.
- Mỗi lần chạm → tàu bắn ra **1 viên đạn**.

Điều này tạo cảm giác:
- vừa né,
- vừa bắn,
- vừa bị rối tay,
- khác với Flappy Bird truyền thống.

---

## 4.2 Gameplay loop
1. Vào game.
2. Tàu tự bay liên tục.
3. Người chơi chạm để giữ tàu ở vị trí an toàn.
4. Né obstacle.
5. Bắn đạn phá một số vật cản hoặc xử lý enemy đơn giản.
6. Nhặt coin.
7. Tốc độ tăng dần theo điểm.
8. Va chạm = chết ngay.
9. Game Over → nhận score, coin → retry hoặc về menu.

---

## 4.3 Điều kiện thua
Người chơi chết ngay khi:
- chạm obstacle,
- chạm enemy,
- chạm enemy bullet,
- rơi ra ngoài vùng chơi nếu có giới hạn màn hình.

Không có:
- shield,
- revive,
- máu nhiều hit.

---

## 5. Phạm vi tính năng của bản MVP

## 5.1 Bắt buộc có
- Main Menu
- Gameplay Scene
- Điều khiển tàu bằng chạm trên/dưới tàu
- Tàu bắn mỗi lần chạm
- 2–3 loại obstacle
- Score
- Coin
- Game Over
- Retry
- Pause
- Save local
- 3 skin tàu
- 2 background/theme
- Sound cơ bản

## 5.2 Có thể thêm nếu còn thời gian
- 1 enemy đơn giản
- 1 event đặc biệt kiểu “danger wave”
- Rewarded ad x2 coin cuối trận
- Interstitial sau vài ván

## 5.3 Không làm ở bản đầu
- Boss hoàn chỉnh
- Nhiều phase boss
- IAP
- Leaderboard online
- Shop lớn nhiều tab phức tạp
- Nhiều loại đạn
- Nâng cấp chỉ số gameplay

---

## 6. Đối tượng người chơi

- Người chơi casual mobile.
- Người thích game ngắn, vào chơi nhanh.
- Fan Flappy Bird hoặc arcade one-touch.
- Người thích game khó vừa phải, kiểu “chết rồi chơi lại ngay”.

---

## 7. Trụ cột thiết kế

## 7.1 Một thao tác – nhiều áp lực
Mỗi chạm vừa là điều khiển vừa là bắn. Người chơi luôn có cảm giác “đang giải quyết nhiều thứ bằng 1 quyết định”.

## 7.2 Học nhanh – thành thạo khó
Ai cũng hiểu được trong vài giây, nhưng để chơi xa cần quen nhịp và phản xạ.

## 7.3 Chơi lại nhanh
Game Over xong phải retry nhanh, không rườm rà.

## 7.4 Scope nhỏ nhưng polish tốt
Ít tính năng hơn nhưng mượt, ổn định, rõ ràng.

---

## 8. Cơ chế game chi tiết

## 8.1 Player movement
Tàu có Rigidbody2D và chịu gravity.

Người chơi không giữ để bay; thay vào đó mỗi chạm tạo một lực tức thời:
- touch trên tàu → add impulse xuống,
- touch dưới tàu → add impulse lên.

### Mục tiêu feel
- dễ hiểu ngay từ lần đầu,
- có quán tính vừa đủ,
- khó nhưng không khó chịu vô lý.

### Tham số cần tinh chỉnh
- gravityScale
- upImpulse
- downImpulse
- maxRiseSpeed
- maxFallSpeed
- rotate follow velocity (nếu dùng)

---

## 8.2 Shooting
Mỗi lần chạm, tàu bắn 1 viên đạn sang phải.

### Mục đích
- tăng nhịp game,
- tạo khác biệt với Flappy Bird,
- cho phép phá một số obstacle hoặc xử lý enemy đơn giản.

### Quy tắc MVP
- chỉ 1 loại đạn,
- đạn bay thẳng,
- không cần nâng cấp,
- không cần auto-fire riêng.

---

## 8.3 Obstacles
Obstacle là thành phần chính của gameplay.

### Loại obstacle đề xuất cho MVP
1. **Asteroid nhỏ** – dễ né, nhỏ, xuất hiện nhiều.
2. **Asteroid lớn** – to hơn, gây áp lực không gian.
3. **Planet fragment / obstacle đặc biệt** – hình khác để tăng đa dạng thị giác.

### Hành vi
- trôi từ phải sang trái,
- có tốc độ theo world speed,
- có thể có loại bắn vỡ được,
- ra khỏi màn hình thì despawn / trả pool.

---

## 8.4 Coin
Coin xuất hiện rải rác theo pattern đơn giản.

### Mục đích
- tạo lựa chọn rủi ro/phần thưởng,
- tăng động lực chơi lại,
- dùng để mở skin/background.

### Quy tắc
- coin không xuất hiện quá dày,
- đường coin nên đặt ở vị trí buộc người chơi mạo hiểm nhẹ,
- coin mỗi run không quá nhiều.

---

## 8.5 Enemy (tùy chọn bản MVP+)
Nếu còn thời gian, thêm 1 enemy rất đơn giản.

### Enemy đề xuất
- bay ngang từ phải sang trái,
- lâu lâu bắn 1 viên đạn thẳng,
- không có AI thông minh,
- có thể bị player bắn hạ.

Nếu thiếu thời gian, có thể **bỏ enemy hoàn toàn** mà game vẫn ổn.

---

## 8.6 Difficulty scaling
Độ khó tăng dần theo thời gian hoặc score.

### Tăng bằng cách
- tăng world scroll speed,
- tăng mật độ obstacle nhẹ,
- tăng tần suất coin/enemy hợp lý.

### Nguyên tắc
- 10–20 giây đầu: làm quen.
- 20–40 giây: bắt đầu căng.
- 40 giây trở đi: khó rõ rệt.

Không nên tăng quá nhanh làm người chơi chết oan sớm.

---

## 9. Hệ thống điểm và tiến trình

## 9.1 Score
Score tăng theo thời gian sống hoặc khoảng cách.

### Đề xuất MVP
- cộng score mỗi frame hoặc mỗi giây theo thời gian sống.
- score hiển thị trên HUD.
- khi chết, nếu score lớn hơn best score thì lưu lại.

## 9.2 Coin economy
Coin thu được trong run sẽ cộng vào tổng coin sau khi game over.

### Mục tiêu economy bản đầu
- có cảm giác tích lũy,
- mở được skin sau vài ván chơi,
- không quá grind.

### Giá gợi ý
- Skin 1: 50 coin
- Skin 2: 120 coin
- Skin 3: 250 coin
- Theme 2: 100 coin

---

## 10. Nội dung bản MVP

## 10.1 Skin tàu
- 1 skin mặc định
- 2 skin mở bằng coin

Skin **chỉ đổi ngoại hình**, không thay đổi gameplay.

## 10.2 Theme/background
- 1 theme mặc định
- 1 theme unlock bằng coin

Theme có thể đổi:
- màu nền,
- sprite background,
- layer parallax.

---

## 11. UI/UX

## 11.1 Main Menu
Bao gồm:
- Play
- Shop
- Settings
- Best Score
- Total Coin

### Mục tiêu UI
- nhìn rõ,
- ít nút,
- load vào nhanh,
- từ menu vào game nhanh.

## 11.2 HUD ingame
Hiển thị:
- Score
- Coin run hiện tại hoặc tổng coin
- Pause button

## 11.3 Pause Panel
- Resume
- Restart
- Back to Menu

## 11.4 Game Over Panel
- Current Score
- Best Score
- Coin earned
- Retry
- Back to Menu
- Rewarded x2 coin (nếu có)

## 11.5 Shop UI
Shop ở bản đầu nên là popup hoặc panel đơn giản, không cần scene riêng.

### Gồm
- list skin tàu,
- list theme/background,
- nút Buy,
- nút Equip,
- hiển thị total coin.

---

## 12. Art direction

## 12.1 Phong cách hình ảnh
- hoạt hình,
- màu sáng,
- vui mắt,
- thân thiện mobile casual.

### Tinh thần
Nhìn vui vẻ, nhưng gameplay có độ thử thách vừa đủ để tạo sự cuốn.

## 12.2 Asset tối thiểu cần có
- 1 tàu mặc định
- 2 tàu skin khác
- 3 obstacle sprite
- 1 bullet sprite
- 1 coin sprite
- 2 bộ background layer
- UI basic icons/buttons
- 1–2 VFX đơn giản

---

## 13. Audio direction

## 13.1 BGM
- 1 bài nhạc nền loop ngắn,
- nhẹ, vui, không quá gắt.

## 13.2 SFX
Cần tối thiểu:
- tap / input
- shoot
- coin collect
- hit / explode
- death
- button click UI

---

## 14. Kỹ thuật triển khai Unity

## 14.1 Công nghệ dùng
- Unity 2D project
- Rigidbody2D + Collider2D
- Input System
- Object Pool cho bullet / coin / obstacle nếu cần
- ScriptableObject cho config nhẹ
- PlayerPrefs hoặc save JSON đơn giản cho local save

## 14.2 Không cần cho bản đầu
- Addressables
- ECS
- kiến trúc service quá lớn
- system event quá phức tạp

---

## 15. Cấu trúc project

```text
Assets/
└── _Game/
    ├── Art/
    │   ├── Sprites/
    │   │   ├── Player/
    │   │   ├── Obstacles/
    │   │   ├── Enemies/
    │   │   ├── Backgrounds/
    │   │   └── UI/
    │   ├── Animations/
    │   └── Materials/
    │
    ├── Audio/
    │   ├── BGM/
    │   └── SFX/
    │
    ├── Prefabs/
    │   ├── Player/
    │   ├── Obstacles/
    │   ├── Enemies/
    │   ├── Projectiles/
    │   ├── Collectibles/
    │   └── UI/
    │
    ├── Scenes/
    │   ├── MainMenu.unity
    │   └── Gameplay.unity
    │
    ├── Scripts/
    │   ├── Core/
    │   ├── Gameplay/
    │   ├── UI/
    │   └── Data/
    │
    ├── ScriptableObjects/
    │   ├── Config/
    │   ├── Skins/
    │   └── Themes/
    │
    └── Resources/
```

---

## 16. Scene design

## 16.1 Scene: MainMenu
### Chứa
- logo / title
- Play button
- Shop button
- Settings button
- best score text
- total coin text

### Optional
- background animation nhẹ
- preview tàu đang equip

## 16.2 Scene: Gameplay
### Cấu trúc đề xuất
```text
Gameplay
├── Main Camera
├── BackgroundRoot
│   ├── BG_Far
│   ├── BG_Mid
│   └── BG_Near
├── GameplayRoot
│   ├── GameManager
│   ├── ScoreManager
│   ├── DifficultyManager
│   ├── Spawner
│   ├── PoolManager
│   └── AudioManager
├── PlayerRoot
│   └── PlayerShip
├── SpawnPoints
│   ├── ObstacleSpawnTop
│   ├── ObstacleSpawnMid
│   ├── ObstacleSpawnBottom
│   ├── CoinSpawn
│   └── EnemySpawn
├── WorldBounds
│   ├── TopLimit
│   ├── BottomLimit
│   └── LeftDespawnZone
└── Canvas
    ├── HUD
    ├── PausePanel
    └── GameOverPanel
```

---

## 17. Danh sách script C# cần có

## 17.1 Core
### `GameManager.cs`
Quản lý state game:
- Menu
- Playing
- Paused
- GameOver

### `SaveManager.cs`
Lưu:
- best score
- total coin
- skin unlock
- equipped skin
- equipped theme

### `AudioManager.cs`
- phát nhạc nền,
- phát SFX gameplay/UI.

### `PoolManager.cs`
- quản lý pool cho bullet,
- coin,
- obstacle nếu cần,
- enemy bullet nếu có enemy.

## 17.2 Gameplay
### `PlayerController.cs`
- nhận input touch/click,
- kiểm tra touch trên/dưới tàu,
- gọi movement,
- gọi fire.

### `PlayerMotor.cs`
- thao tác Rigidbody2D,
- add impulse lên/xuống,
- clamp velocity.

### `PlayerShooter.cs`
- tạo bullet,
- set vị trí spawn,
- set hướng bắn.

### `PlayerCollision.cs`
- xử lý va chạm death,
- nhặt coin,
- xử lý hit vào enemy/obstacle.

### `Projectile.cs`
- quản lý đường bay,
- auto despawn,
- va chạm mục tiêu.

### `ScrollingMover.cs`
- cho object di chuyển sang trái theo world speed.

### `Spawner.cs`
- spawn obstacle,
- spawn coin,
- spawn enemy nếu có.

### `Obstacle.cs`
- nhận hit nếu destructible,
- despawn khi ra khỏi màn hình.

### `EnemySimple.cs`
- enemy MVP đơn giản,
- bắn thẳng,
- có thể bị phá.

### `ScoreManager.cs`
- tăng score theo thời gian,
- cập nhật HUD,
- lưu best score khi game over.

### `DifficultyManager.cs`
- tăng tốc độ,
- tăng spawn rate theo score.

## 17.3 UI
### `HUDUI.cs`
- hiển thị score,
- coin,
- pause.

### `MainMenuUI.cs`
- play,
- mở shop,
- mở settings.

### `GameOverUI.cs`
- score,
- best,
- coin earned,
- retry,
- back menu.

### `ShopUI.cs`
- render list skin/theme,
- buy/equip,
- hiển thị total coin.

## 17.4 Data
### `GameConfigSO.cs`
- tốc độ cơ bản,
- tốc độ tăng độ khó,
- score rate,
- spawn timing.

### `SkinDataSO.cs`
- id,
- tên,
- sprite,
- giá,
- default unlock?

### `ThemeDataSO.cs`
- id,
- background set,
- giá,
- default unlock?

---

## 18. Prefab list

```text
Prefabs/
├── PlayerShip.prefab
├── Bullet_Player.prefab
├── Bullet_Enemy.prefab
├── Coin.prefab
├── Obstacle_AsteroidSmall.prefab
├── Obstacle_AsteroidBig.prefab
├── Obstacle_Planet.prefab
├── Enemy_Simple.prefab
├── Background_ThemeBlue.prefab
├── Background_ThemePurple.prefab
├── HUD.prefab
├── GameOverPanel.prefab
└── ShopItem.prefab
```

---

## 19. Data balance ban đầu

## 19.1 Player tuning gợi ý
- gravityScale: 2.5
- upImpulse: 5.0
- downImpulse: 4.0
- maxRiseSpeed: 6.0
- maxFallSpeed: 7.0

## 19.2 World tuning gợi ý
- base scroll speed: 3.0
- difficulty step: +0.15 mỗi 10–15 giây
- coin chance: thấp vừa phải

## 19.3 Gameplay target
- người mới: sống được 10–20 giây
- người quen cơ chế: sống được 40–60 giây
- score tăng đều, không quá chậm

---

## 20. Cắt giảm scope để kịp deadline

Nếu bị trễ tiến độ, cắt theo thứ tự sau:
1. enemy
2. rewarded ad
3. interstitial
4. theme thứ hai
5. shop chi tiết
6. visual polish phụ

Không được cắt:
- cảm giác điều khiển,
- loop gameplay,
- score,
- retry,
- save.

---

## 21. Lộ trình sản xuất 4 tuần

## Tuần 1 – Core Gameplay
### Mục tiêu
Làm game chơi được.

### Công việc
- tạo project Unity 2D,
- setup Input System,
- tạo 2 scene,
- dựng player,
- hoàn thiện movement,
- thêm shooting,
- thêm obstacle đầu tiên,
- game over,
- retry,
- HUD score.

### Kết quả tuần 1
- có thể vào game,
- điều khiển tàu,
- né obstacle,
- bắn,
- chết và chơi lại.

## Tuần 2 – Endless Loop
### Mục tiêu
Hoàn thiện loop chính.

### Công việc
- thêm spawner,
- thêm 2–3 obstacle,
- thêm coin,
- save high score,
- save total coin,
- background parallax,
- difficulty scaling.

### Kết quả tuần 2
- gameplay loop hoàn chỉnh,
- đã có progression cơ bản.

## Tuần 3 – Content + UI
### Mục tiêu
Biến prototype thành game nhỏ hoàn chỉnh.

### Công việc
- main menu,
- shop panel,
- 3 skin,
- 2 theme,
- sound,
- pause,
- polish game over.

### Kết quả tuần 3
- game có thể đưa người khác test.

## Tuần 4 – Polish + Build
### Mục tiêu
Chạy ổn trên điện thoại.

### Công việc
- build Android,
- tối ưu object spawn,
- thêm pooling,
- test aspect ratio,
- test input,
- cân bằng độ khó,
- thêm rewarded/interstitial nếu còn thời gian.

### Kết quả tuần 4
- có bản build nội bộ đủ tốt để soft test.

---

## 22. Testing checklist

## 22.1 Gameplay test
- cảm giác điều khiển có dễ hiểu không?
- touch trên/dưới tàu có rõ không?
- có chết oan vì spawn xấu không?
- bullet có hữu ích không?
- game over có nhanh và rõ không?

## 22.2 UI test
- HUD có che gameplay không?
- chữ có đủ to trên mobile không?
- shop có dễ hiểu không?
- retry có nhanh không?

## 22.3 Performance test
- có tụt FPS không?
- có lag khi spawn nhiều obstacle không?
- có GC spike khi bắn nhiều đạn không?
- có vấn đề trên màn hình tỷ lệ khác nhau không?

---

## 23. Hướng mở rộng sau MVP

Sau khi bản MVP ổn định, có thể mở rộng:
- mini boss,
- special wave,
- thêm enemy types,
- rewarded ads hoàn chỉnh,
- interstitial,
- IAP,
- leaderboard,
- nhiều theme/map,
- event/mission ngày.

---

## 24. Kết luận

Bản GDD này được tối ưu để:
- bám đúng tinh thần SpaceGo,
- giữ lại điểm khác biệt của gameplay,
- giảm scope về mức khả thi trong 1 tháng,
- đủ chi tiết để dùng triển khai Unity ngay.

Mục tiêu quan trọng nhất của dự án không phải số lượng tính năng, mà là:
1. điều khiển tốt,
2. vòng chơi mượt,
3. retry nhanh,
4. build mobile ổn định.

Nếu hoàn thành đúng GDD này, bạn sẽ có một bản MVP đủ tốt để test người chơi, rồi từ đó mới quyết định có nâng lên hướng boss / hardcore / monetization sâu hơn hay không.

