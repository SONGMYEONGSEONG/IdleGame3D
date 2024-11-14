# IdleGame3D
SSC_Unity_6gen_IdleGame3D

## [프로젝트 소개]
![image](https://github.com/user-attachments/assets/c9396aa3-6fa8-46f3-84e9-b66f3c8b1a64)

개인프로젝트 Unity3D 
3D 방치형 게임

개발환경 - Unity3D, C#, Visual Studio

---
## [프로젝트 목표]
- CharaterController 및 FSM 을 사용하여 실제 개발에 적용시켜보기
- 아이템,캐릭터스테이터스,스테이지 및 등 데이터관리에 중점을 두고 관리해보기 -> 해당 부분은 SO로 관라히였습니다.

---
## [개발 기간]
2024.11.11(월) ~ 2024.11.14(목) (4일)
개발 인원 : 1명

---

## [기능 구현]
![1](https://github.com/user-attachments/assets/dabc6d37-010b-4d1f-a31b-54d74814fdea)

### 1. 플레이어 & Enemy AI 구현
플레이어와 Enemy의 OverlapSphere 메서드를 사용하여 구현하였고, 해당 범위 안에 있는경우 해당 적을 쫒아가게 설정하였습니다.

---

### 2. 인벤토리 구현
인벤토리를 구현하여 Enemy를 쓰러트리면 Enemy의 SO데이터를 통하여 DropItem을 랜덤으로 하나 호출하여 인벤토리에 넣게 구현하였습니다.

---

#### 3. ScriptableObject를 이용하여 데이터 관리
![image](https://github.com/user-attachments/assets/468fb16f-7504-4b64-9d65-f041cff75192)
해당 게임에서 필요한 Item,Player스텟,Enemy스텟 등등을 SO로 관리하여 필요할떄 호출하여 사용하고,
저장/불러오기를 위해 해당 SO에 저장하는 방식으로 사용했습니다. 

---


