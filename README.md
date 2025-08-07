# AuctionSite
拍賣網站

## 簡介
用Visual Studio 的 asp.net (web form)驅動，讓使用者拍賣下標及自動結標的**拍賣網站** 

主要功能有下面幾項：
1. 登入系統（登入後才能借用，否則只能看到登入跟註冊頁面）
    * 註冊帳號（要有姓名、用戶名稱、密碼、email、電話）
    * 登入（用用戶名、密碼）
    * 登出

2. 賣東西
    * 拍賣物品：輸入想要賣的商品及其資訊
        * 商品資訊：名稱、說明、分類、商品圖片
        * 拍賣：起標價、開始時間、結束時間
    * 可查看個人拍賣紀錄
        * 商品狀態 (拍賣失敗、成功、無人競標、競標中、未上架)
        * 價錢 (賣家出價/競標價/最後價格)
        * 買家

3. 買東西
    * 用分類查詢商品，顯示正在拍賣的商品及其目前的最高價格（尚未開始或已經結束的均不顯示）
    * 選定一商品後會出現此商品及其賣方的資訊，可輸入價錢下標
    * 拍賣結束後，系統自動寄信通知得標者（出價最高的人）
    * 可查看個人下標紀錄</br>
      是否得標及那時的出價

## 使用說明與介面
### 登入系統
#### 登入
<img width="1920" height="884" alt="螢幕擷取畫面 2024-12-30 225321" src="https://github.com/user-attachments/assets/237e20c7-1647-4879-b961-f56c82c55f3c" />

<p ></p>

* 其中一個輸入錯誤會有提醒</br>
      <img height="90" alt="image" src="https://github.com/user-attachments/assets/668836db-f0a1-4061-b9b4-e63d283cb669" />
<p ></p>

&nbsp;&nbsp; - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
#### 註冊帳號
<img width="1920" height="883" alt="螢幕擷取畫面 2024-12-30 225346" src="https://github.com/user-attachments/assets/4d0c9558-e7e3-478f-8ca9-596c2f58d2d8" />
<p ></p>

* 資料輸入不完整、用戶名稱已存在、兩個密碼不同會有提醒</br>
   <img height="130" alt="螢幕擷取畫面 2025-08-07 161347" src="https://github.com/user-attachments/assets/cdef43cf-c72d-4192-864c-78f0d0a6a6d7" />
   <img height="130" alt="螢幕擷取畫面 2025-08-07 161417" src="https://github.com/user-attachments/assets/98f97092-054b-438f-8b60-cf9bfb983a93" />
   <img height="130" alt="螢幕擷取畫面 2025-08-07 161436" src="https://github.com/user-attachments/assets/39dc819a-e3b8-477f-a325-13358d5912a4" />
<p ></p>

&nbsp;&nbsp; - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
#### 登出
<img width="1920" height="636" alt="螢幕擷取畫面 2024-12-30 225917" src="https://github.com/user-attachments/assets/59aa15de-7036-4383-8b22-e53b84109a51" />

### 賣東西
#### 拍賣物品
<img width="1920" height="886" alt="螢幕擷取畫面 2024-12-30 225947" src="https://github.com/user-attachments/assets/07aa90eb-713c-4e6c-af9b-9889a5bcbe0b" />
<p ></p>

* 可從電腦上傳圖片、選日期</br>
   <img height="350" alt="網頁設計 (3)" src="https://github.com/user-attachments/assets/4d0f9b50-1b88-45fa-9fb2-b3539493a4cf" />
   <img height="350" alt="網頁設計 (4)" src="https://github.com/user-attachments/assets/36790d21-4397-4dcb-88ab-25c4c92a25a3" />
   <img height="350" height="718" alt="網頁設計 (5)" src="https://github.com/user-attachments/assets/6098c994-4372-4304-81f2-ee5918b9cfe5" />
<p ></p>

&nbsp;&nbsp; - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
#### 拍賣紀錄
不同商品狀態顏色不同
<img width="1593" height="736" alt="網頁設計 (13)" src="https://github.com/user-attachments/assets/12b7fd13-d882-44be-90dd-9d37d2bb8a4e" />
* 未上架、競標中</br>
   <img  height="150" alt="網頁設計 (15)" src="https://github.com/user-attachments/assets/634fa906-d0ad-4e16-8318-5c250cd331ce" />
   <img  height="150" alt="網頁設計 (19)" src="https://github.com/user-attachments/assets/8fe1ae17-a663-4857-84cc-3ddb0456970c" />

* 沒紀錄</br>
   <img height="400" alt="網頁設計 (14)" src="https://github.com/user-attachments/assets/3cd6bf1d-04d8-4963-8f1a-ee3d152ae5d6" />

&nbsp;&nbsp; - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
### 買東西
#### 首頁
點擊商品能看詳細內容、介紹</br>
<img width="1920" height="881" alt="螢幕擷取畫面 2024-12-30 230021" src="https://github.com/user-attachments/assets/9c26b3fb-5a6c-4d4e-baf6-f93193dba5c3" />

* 依分類查詢商品</br>
  <img width="1578" height="680" alt="網頁設計 (9)" src="https://github.com/user-attachments/assets/99b699a4-737c-4bc6-83ac-4c482dde397c" />

* 沒任何商品時</br>
  <img width="1658" height="577" alt="網頁設計 (10)" src="https://github.com/user-attachments/assets/3233e153-1395-4b41-98ad-71af0c11289b" />

&nbsp;&nbsp; - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
#### 商品介紹頁面
點選 `我要下標` 後會到出價頁面
<img width="1697" height="779" alt="網頁設計 (8)" src="https://github.com/user-attachments/assets/61d2a93f-67fc-43ef-bd9a-ce77b7786a00" />

&nbsp;&nbsp; - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
#### 出價下標
<img width="1627" height="637" alt="網頁設計 (6)" src="https://github.com/user-attachments/assets/8aa2ecc7-33ab-4a4f-b963-d0ae39626b46" />
<p ></p>

* 價錢輸入失敗會有提醒</br>
   <img height="200" alt="網頁設計 (7)" src="https://github.com/user-attachments/assets/06768d75-c4f8-4b47-b81b-eb2a192983b8" />
<p ></p>

&nbsp;&nbsp; - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
#### 下標紀錄
會顯示下標的商品是否得標及那時的出價 (還沒結束拍賣的也會顯示未得標)
<img width="1654" height="752" alt="網頁設計 (16)" src="https://github.com/user-attachments/assets/1aab2040-7f3d-4830-b866-356cc6dab928" />

* 如果成功得標會收到mail (商品拍賣時間結束會寄信給出價最高者)</br>
   <p>
      <img height="150" align="top" alt="網頁設計 (12)" src="https://github.com/user-attachments/assets/9c9e9025-4e85-4d76-8f5c-19b5ba07bcfa" />
      <img height="300" alt="網頁設計 (17)" src="https://github.com/user-attachments/assets/ffa5e383-d620-4317-8886-3255bb4cc2cf" />
   </p>

* 沒有下標過</br>
   <img height="350" alt="網頁設計 (11)" src="https://github.com/user-attachments/assets/276cff8c-0136-4df7-8b91-606896adc2a8" />


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

4. 找到伺服器總管底下的 `資料連結` 底下的 `加入連結`點入，`資料來源` 選 Access 那個，`資料庫檔名` 選專案中的 `.accdb` 檔，按 `確認`
5. 分頁開啟 `HomePage.aspx` 並按綠色箭頭</br>
    <img width="500" alt="網頁設計 (1)" src="https://github.com/user-attachments/assets/fcd4f9ab-fecc-40dc-b386-7e0a2aac9347" />

6. 點擊首頁就會進入登入頁面
   <img width="1278" height="703" alt="網頁設計 (2)" src="https://github.com/user-attachments/assets/fea18c01-94e1-4253-9551-6997f567754f" />
