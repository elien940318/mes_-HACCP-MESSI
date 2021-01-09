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
    
    

Logo
===
<p align="center">
   <img width="500" src="https://user-images.githubusercontent.com/24702528/104091460-dd9a2f80-52c0-11eb-9670-ddb1ec496ba8.png">  
</p>

Envoirment
===
    * Server: Linux (used Raspberry-Pi 4)
    * DBMS: Maria DB
    * Framework: .Net (Winform)

<br><br><br><br>

<h1 align="center">Design</h1>

Login
---
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

