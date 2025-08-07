# AuctionSite
拍賣網站

## 簡介
用Visual Studio 的 asp.net (web form)驅動，讓使用者拍賣下標及自動結標的**拍賣網站** 

主要功能有下面幾項：
1. 登入系統（登入後才能借用，否則只能看到登入跟註冊頁面）
    * 註冊帳號（要有用戶名稱、密碼、email、電話、身分證字號）
    * 登入（用用戶名、密碼）
    * 登出

2. 賣東西
    * 拍賣物品：輸入想要賣的商品及其資訊
        * 商品資訊：名稱、說明、分類、商品圖片
        * 拍賣：起標價、開始時間、結束時間
    * 可查看個人拍賣紀錄

3. 買東西
    * 用分類查詢商品，顯示正在拍賣的商品（尚未開始或已經結束的均不顯示）
    * 選定一商品後會出現此商品及其賣方的資訊，可輸入價錢下標
    * 拍賣結束後，系統自動寄信通知得標者（出價最高的人）
    * 可查看個人下標紀錄

## 使用說明與介面



## 如何安裝
1. 下載專案到電腦本地端的Downloads資料夾
    ```
    cd %HOMEPATH%\Downloads
    git clone https://github.com/Dora-meow/AuctionSite.git
    ```
    * 也可點進[https://github.com/Dora-meow/AuctionSite](https://github.com/Dora-meow/AuctionSite)
    按綠色的code按鈕下載壓縮檔，並解壓縮

2. 打開 Visual Studio 點 `開啟專案或解決方案`</br>
    <img width="500" alt="image" src="https://github.com/user-attachments/assets/ae1516c3-239b-466b-99fe-5057b675a4d4" />
3. 找到 `myWeb2` 中的 `myWeb2.sln` 並開啟</br>
    <img width="500" alt="網頁設計" src="https://github.com/user-attachments/assets/264f8baf-61c1-4032-8ab7-73c8c4f538f4" />

4. 分頁開啟 `HomePage.aspx` 並按綠色箭頭
    <img width="1427" height="519" alt="網頁設計 (1)" src="https://github.com/user-attachments/assets/fcd4f9ab-fecc-40dc-b386-7e0a2aac9347" />

5. 
6. 
