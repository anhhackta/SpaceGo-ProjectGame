---
Dự Án: " "
---


---

# 📑 Game Design Document (GDD) – _SpaceGo_ (Hardcore Edition)

## 1. Thông Tin Chung

- **Tên game:** SpaceGo
    
- **Thể loại:** Arcade – Endless Scroller (hardcore)
    
- **Nền tảng:** Mobile (Android, iOS)
    
- **Engine:** Unity
    
- **Phong cách hình ảnh:** Không gian hoạt hình vui nhộn, nhưng gameplay “ác độc” khó chịu.
    
- **Đối tượng:** Người chơi casual muốn thử thách cực hạn, fan Flappy Bird, game thủ thích độ khó “rage quit”.
    

---

## 2. Gameplay Core

### 2.1 Cơ chế "Nạp Bay"

- **Click trên tàu:** đẩy tàu xuống.
    
- **Click dưới tàu:** kéo tàu lên.
    
- **Trọng lực:** luôn kéo tàu xuống → tạo độ khó điều khiển cao.
    
- **Mỗi click = bắn đạn.**
    

### 2.2 Vòng lặp gameplay

1. Tàu tiến liên tục về phía trước.
    
2. Người chơi **né hành tinh**, **tránh thiên thạch**, **kẻ địch bắn đạn**.
    
3. Bắn đạn để dọn chướng ngại (tốn thao tác → càng rối tay).
    
4. Thu thập **coin** → mua skin.
    
5. Qua mốc điểm → gặp **Boss**:
    
    - Boss không chạy → player chỉ né + bắn.
        
    - Boss có **pattern điên cuồng** (spam đạn, tia laser, thiên thạch rơi).
        
    - Thắng → tăng tốc độ game + mở skin/map mới.
        

---

## 3. Độ Khó (Hardcore Factor)

- **Không có Shield.** Ăn hit = chết ngay.
    
- **Không hồi sinh.** Chết = chơi lại từ đầu.
    
- **Coin hiếm:** skin giá cao, ép player chơi nhiều mới có được.
    
- **Tốc độ tăng nhanh:** mỗi 200–300 điểm, tốc độ game tăng dần.
    
- **Kẻ địch thông minh:** bắn đạn chặn hướng di chuyển.
    
- **Boss cực gắt:** pattern bắn dày đặc, cần phản xạ nhanh.
    

---

## 4. Progression

- **Điểm (Score):** càng lâu → càng khó.
    
- **Coin:** dùng để mua skin (tàu, map).
    
- **Skin tàu:** chỉ **thay đổi hình dáng** (không buff gameplay).
    
- **Skin map:** đổi background (thiên hà xanh, sao tím, hố đen, siêu tân tinh).
    
- **Boss milestones:** 1000 / 2000 / 3000 điểm… mỗi lần boss khó hơn.
    

---

## 5. Monetization (Kinh doanh)

- **Shop:**
    
    - Skin tàu: giá **cao**, buộc grind coin lâu mới mua được.
        
    - Skin map: unlock bằng coin hoặc boss reward.
        
- **Quảng cáo:**
    
    - **Rewarded Ads:** chỉ có _x2 coin khi kết thúc game_.
        
    - **Interstitial Ads:** hiển thị thỉnh thoảng (sau vài ván).
        
    - ❌ Không có quảng cáo hồi sinh.
        
- **In-App Purchase (IAP):**
    
    - Mua coin trực tiếp (để tiết kiệm thời gian).
        
    - Mua skin premium.
        
    - Mua gói “remove ads”.
        

---

## 6. UI/UX

- **Main Menu:** Play – Shop – Settings – Leaderboard.
    
- **Ingame UI:**
    
    - Score (trên cùng giữa).
        
    - Coin (trên phải).
        
    - Pause (góc trái).
        
- **Shop UI:**
    
    - Grid hiển thị skin tàu (locked/unlocked).
        
    - Tab map (background).
        
    - Giá coin rõ ràng, **skin đắt** để ép grind.
        

---

## 7. Art & Sound

- **Art style:** Hoạt hình vui nhộn, trái ngược gameplay khó chịu → tạo sự hài hước “troll player”.
    
- **Âm nhạc:**
    
    - Nhạc nền vui vẻ nhưng tempo càng lúc càng nhanh (tạo áp lực).
        
    - SFX click, bắn, nổ, “death sound” gây tức cười.
        

---

## 8. Công Nghệ (Unity Implementation)

- **Physics:** Unity 2D physics (gravity, rigidbody).
    
- **Object Pooling:** spawn thiên thạch, enemy, đạn.
    
- **ScriptableObject:** config boss pattern, enemy stats, skin data.
    
- **Ads & IAP:** Unity Ads / AdMob, Unity IAP.
    
- **Leaderboard:** Google Play Games / Apple Game Center.
    

---

## 9. Roadmap Phát Triển

- **Tháng 1:** Core mechanic (nạp bay + bắn).
    
- **Tháng 2:** Chướng ngại + kẻ địch cơ bản.
    
- **Tháng 3:** Boss + tăng độ khó + coin system.
    
- **Tháng 4:** Shop + Skin + Ads.
    
- **Tháng 5:** Polish art + SFX + music.
    
- **Tháng 6:** Soft launch.
    

---

🔥 Điểm mấu chốt của **SpaceGo Hardcore Edition**:

- **Không khoan nhượng.** Chết 1 lần = game over.
    
- **Skin cực đắt.** Người chơi phải grind hoặc nạp tiền.
    
- **Độ khó leo thang nhanh.** Chỉ người phản xạ tốt mới đi xa.
    
- **Gameplay “rage quit” nhưng gây nghiện.**
    

---
