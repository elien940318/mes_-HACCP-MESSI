<h1 align="center">HACCP_MESSI</h1>

Project description
===
    수행기관: 경상대학교 스마트공장지원센터
    
    프로젝트 목표: 
      쌀국수 제품을 생산하는 가상의 제조공정을 대상으로 하여
      생산성 향상을 도모하는 간이 MES 시스템 구축

    지도교수: 경상대학교 산업시스템공학과 도남철 교수
    멘토: HACCP&SmartFactory 전보근 개발팀장
   
Collaborator
===
    강창기
    김동욱
    김문혁
    박근도
    조영현
    
Envoirment
===
    * Server: Linux (used Raspberry-Pi 4)
    * DBMS: Maria DB
    * Framework: .Net (Winform)

<br><br><br><br>


Logo
===
<p align="center">
   <img width="500" src="https://user-images.githubusercontent.com/24702528/104091460-dd9a2f80-52c0-11eb-9670-ddb1ec496ba8.png">  
</p>

<!--<h1 align="center">Design</h1>-->
Design
===

Login
---
    * 3초간의 Progress Bar 화면 출력 후 Login View 출력
    * OAuth 2.0 도입 예정
<p align="center">
   <img src="https://user-images.githubusercontent.com/24702528/104092309-7bdcc400-52c6-11eb-944c-6afe9fb609e9.png" width="600">
</p>


Home
---
    * 최근 데이터 기준하여 한달간의 생산량을 그래프로 출력
        1) 한달 간의 양품,불량품 Column Chart   
        2) 날짜별 불량률 Line Chart   
        3) 한달 총 합산 불량률 Doughnut Chart
<p align="center">
   <img src="https://user-images.githubusercontent.com/24702528/104092310-7d0df100-52c6-11eb-8025-7f0eac48ab2b.png" width="600">
</p>



Information
---
    * 거래처, 품목, 창고 및 BOM 관련 기준정보
<p align="center">
    <img src="https://user-images.githubusercontent.com/24702528/104092934-9022c000-52ca-11eb-82b3-cab81c953d6e.png" width="400">
    <img src="https://user-images.githubusercontent.com/24702528/104092940-95800a80-52ca-11eb-9849-58636d423fe0.png" width="400">
    <img src="https://user-images.githubusercontent.com/24702528/104092936-91ec8380-52ca-11eb-9fd4-7d870bfb009a.png" width="400">
    <img src="https://user-images.githubusercontent.com/24702528/104092938-931db080-52ca-11eb-8648-a493dcbe6f13.png" width="400">
</p>

Management
---
    * 품목 입출고 및 재고 현황 관리 
<p align="center">
    <img src="https://user-images.githubusercontent.com/24702528/104092615-636da900-52c8-11eb-93e0-edc5cf6b5678.png" width="400">
    <img src="https://user-images.githubusercontent.com/24702528/104092640-931cb100-52c8-11eb-8772-885c626b3df8.png" width="400">
    <img src="https://user-images.githubusercontent.com/24702528/104092708-11795300-52c9-11eb-8557-0a9db75e3f1c.png" width="400">
    <img src="https://user-images.githubusercontent.com/24702528/104092709-12aa8000-52c9-11eb-8bdb-52d268127f18.png" width="400">
</p>

Production
---
    * 작업지시 및 생산실적 관리 
<p align="center">
    <img src="https://user-images.githubusercontent.com/24702528/104092834-e5aa9d00-52c9-11eb-919c-5682fdcff217.png" width="300">
    <img src="https://user-images.githubusercontent.com/24702528/104092837-e8a58d80-52c9-11eb-97d5-e70fe2058d11.png" width="300">
    <img src="https://user-images.githubusercontent.com/24702528/104092838-ea6f5100-52c9-11eb-9a5a-7ab65db2c294.png" width="300">
    <img src="https://user-images.githubusercontent.com/24702528/104092841-ed6a4180-52c9-11eb-9b14-fceb1042e8d8.png" width="400">
    <img src="https://user-images.githubusercontent.com/24702528/104092844-f0653200-52c9-11eb-9dde-583153057048.png" width="400">
</p>
