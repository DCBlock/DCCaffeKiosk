## DCaffeKios .Net Client

까페 무인 주문을 위한 터치 스크린 UI 클라이언트

## Building the source

Visual Studio 2017 .NET C#

## Executables

1. Swordsoft/mousetrack 설치
2. Spoqa Han Sans Font 설치
3. BIXOLON SRP-330II 프린터 USB 연결 확인
4. RFID Reader USB 연결 확인
5. DCCaffeKisok.exe 실행

## Running Application

### 'BIXOLON SRP-330II' 프린터 드라이버 설치

[Windows Driver 다운로드 - software_srp-330ii_332ii_windows_driver_v1.2.0.zip](http://bixolon.com/upload/download/software_srp-330ii_332ii_windows_driver_v1.2.0.zip)

### font 설치

Spoqa Han Sans - KR Original

> 무료로 사용 가능한 폰트 중에서 한글/영문 등의 동일한 다국어 폰트가 필요했다.
> 
> Google Noto Sans CJK Font
> 
> 구글과 어도비에 의해 제작된 본고딕(Noto Sans CJK/Source Han Sans)으로 한국어, 중국어 번체와 간체, 일본어와 라틴어, 그리스어, 키릴 자모를 지원하는 한중일 공통 오픈소스 글꼴이다. 개발기간만 3년이 걸렸을 만큼 완성도가 높은 폰트라고 한다.
> > Noto Sans는 OTF 포멧만 지원하여 .NET에서 사용을 할 수가 없다.
> 
> Spoqa Han Sans Font
> 
> 스포카 한 산스는 스포카의 제품의 다국어 UI에 대응하기 위해 Noto Sans와 Lato를 바탕으로 커스텀한 글꼴이다.
> > OTF, TTF 포멧을 지원하며, NOTO 기반이며 다국어 폰트를 지원한다.

[다운로드](https://github.com/spoqa/spoqa-han-sans/releases/download/2.1.0/SpoqaHanSans_original.zip)

### swordsoft mousetrack 설치

for Mouse Click Effect
> 사용자가 화면에 터치가 되었는지 UI로 효과를 보여주기 위해서 사용한다.
> 터치 이벤트에 대한 효과를 직접 구현해도 되지만 추후에 기능을 추가하는 것으로 한다.

[다운로드](http://www.swordsoft.idv.tw/mousetrack/)

## License

GNU GENERAL PUBLIC LICENSE 3.0

### [HashLib](https://archive.codeplex.com/?p=hashlib#HashLib/)
- V2.0.1
- MIT License
- SHA256 사용

### [Newtonsoft.Json](https://www.newtonsoft.com/json)
- V12.0.1
- MIT License
- RESTAPI 요청/응답 데이터 Serialize/Deserialize 사용

### [QRCoder](https://github.com/codebude/QRCoder/)
- v1.3.5
- The MIT License (MIT)
- 사용내역 조회를 위한 일회용 임시 URL QRCode 생성에 사용

### [RestSharp](http://restsharp.org/)
- V106.5.4
- Apache License 2.0
- RESTAPI Request/Response를 위한 Client 구현 사용

### [SharpLibHid](https://github.com/Slion/SharpLibHid)
- V1.4.3
- GNU General Public License
- RFID Reader 기기가 HID 장치로 인식되어, 입력되는 RAW Key Data를 버퍼에서 직접 읽기위해 사용

### [SharpLibWin32](https://github.com/Slion/SharpLibWin32)
- V0.1.7
- GNU General Public License
- SharpLibHid를 위한 win32 Wrapper

